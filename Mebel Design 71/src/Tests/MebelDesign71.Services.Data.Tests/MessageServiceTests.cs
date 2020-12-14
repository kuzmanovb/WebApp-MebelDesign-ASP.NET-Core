namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;

    using Microsoft.EntityFrameworkCore;

    using Xunit;

    public class MessageServiceTests : IDisposable
    {

        private readonly IMessagesService messagesService;

        private IDeletableEntityRepository<Message> messageRepository;
        private IDeletableEntityRepository<SendMessage> sendMessageRepository;

        private ApplicationDbContext connection;
        private IHtmlSanitizer htmlSanitizer;

        public MessageServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.messageRepository = new EfDeletableEntityRepository<Message>(this.connection);
            this.sendMessageRepository = new EfDeletableEntityRepository<SendMessage>(this.connection);

            this.htmlSanitizer = new HtmlSanitizer();

            this.messagesService = new MessagesService(this.messageRepository, this.sendMessageRepository, this.htmlSanitizer);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task TestAddMessageAsync()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            await this.messagesService.AddMessageAsync(messageInputModel);
            var messageFirstName = this.messageRepository.All().FirstOrDefault().FirstName;

            Assert.Equal("Test First Name", messageFirstName);
        }

        [Fact]
        public async Task TestAddSendMessageAsync()
        {
            var sendMessageInputModel = new SendMessageInputModel
            {
                About = "Test About",
                Description = "Test Description",
                Email = "Test Email",
            };

            await this.messagesService.AddSendMessageAsync(sendMessageInputModel);
            var sendMessageToEmail = this.sendMessageRepository.All().FirstOrDefault().ToEmail;

            Assert.Equal("Test Email", sendMessageToEmail);
        }

        [Fact]
        public async Task TestGetAllMessages()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            await this.messagesService.AddMessageAsync(messageInputModel);
            await this.messagesService.AddMessageAsync(messageInputModel);
            await this.messagesService.AddMessageAsync(messageInputModel);

            var messageCount = this.messagesService.GetAllMessages().Count;

            Assert.Equal(3, messageCount);
        }

        [Fact]
        public async Task TestGetAllSendMessages()
        {
            var sendMessageInputModel = new SendMessageInputModel
            {
                About = "Test About",
                Description = "Test Description",
                Email = "Test Email",
            };

            await this.messagesService.AddSendMessageAsync(sendMessageInputModel);
            await this.messagesService.AddSendMessageAsync(sendMessageInputModel);

            var sendMessageCount = this.messagesService.GetAllSendMessages().Count;

            Assert.Equal(2, sendMessageCount);
        }

        [Fact]
        public async Task TestGetIsDeletedMessages()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            var firstId = await this.messagesService.AddMessageAsync(messageInputModel);
            var secondId = await this.messagesService.AddMessageAsync(messageInputModel);

            await this.messagesService.DeleteMessageAsync(firstId);
            await this.messagesService.DeleteMessageAsync(secondId);

            var deletedMessages = this.messagesService.GetIsDeletedMessages();

            Assert.Equal(2, deletedMessages.Count);
        }

        [Fact]
        public async Task TestGetMessageById()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            var id = await this.messagesService.AddMessageAsync(messageInputModel);

            var expectMessage = this.messagesService.GetMessageById(id);

            Assert.Equal(id, expectMessage.Id);
        }

        [Fact]
        public async Task TestGetSendMessagesById()
        {
            var sendMessageInputModel = new SendMessageInputModel
            {
                About = "Test About",
                Description = "Test Description",
                Email = "Test Email",
            };

            var id = await this.messagesService.AddSendMessageAsync(sendMessageInputModel);

            var expectMessage = this.messagesService.GetSendMessageById(id);

            Assert.NotNull(expectMessage);
        }

        [Fact]
        public async Task TestDeleteMessageAsync()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            var id = await this.messagesService.AddMessageAsync(messageInputModel);

            await this.messagesService.DeleteMessageAsync(id);

            var expectMessage = this.messageRepository.AllWithDeleted().Where(m => m.Id == id).FirstOrDefault();

            Assert.True(expectMessage.IsDeleted);
        }

        [Fact]
        public async Task TestDeleteSendMessageAsync()
        {
            var sendMessageInputModel = new SendMessageInputModel
            {
                About = "Test About",
                Description = "Test Description",
                Email = "Test Email",
            };

            var id = await this.messagesService.AddSendMessageAsync(sendMessageInputModel);

            await this.messagesService.DeleteSendMessageAsync(id);

            var expectMessage = this.sendMessageRepository.AllWithDeleted().Where(m => m.Id == id).FirstOrDefault();

            Assert.True(expectMessage.IsDeleted);
        }

        [Fact]
        public async Task TestRestoreMessageAsync()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            var id = await this.messagesService.AddMessageAsync(messageInputModel);

            await this.messagesService.DeleteMessageAsync(id);

            await this.messagesService.RestoreMessageAsync(id);

            var expectMessage = this.messageRepository.All().Where(m => m.Id == id).FirstOrDefault();

            Assert.NotNull(expectMessage);
        }

        [Fact]
        public async Task TestHardDeleteMessageAsync()
        {
            var messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            var id = await this.messagesService.AddMessageAsync(messageInputModel);

            await this.messagesService.HardDeleteMessageAsync(id);

            var message = this.messageRepository.AllWithDeleted().ToList();

            Assert.Empty(message);
        }
    }
}

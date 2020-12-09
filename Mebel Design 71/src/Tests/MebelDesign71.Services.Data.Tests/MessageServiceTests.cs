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

        private MessageInputModel messageInputModel;
        private SendMessageInputModel sendMessageInputModel;

        public MessageServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.messageRepository = new EfDeletableEntityRepository<Message>(this.connection);
            this.sendMessageRepository = new EfDeletableEntityRepository<SendMessage>(this.connection);

            this.htmlSanitizer = new HtmlSanitizer();

            this.InitializeFields();

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
            await this.messagesService.AddMessageAsync(this.messageInputModel);
            var messageFirstName = this.messageRepository.All().FirstOrDefault().FirstName;

            Assert.Equal("Test First Name", messageFirstName);
        }

        [Fact]
        public async Task TestAddSendMessageAsync()
        {
            await this.messagesService.AddSendMessageAsync(this.sendMessageInputModel);
            var sendMessageToEmail = this.sendMessageRepository.All().FirstOrDefault().ToEmail;

            Assert.Equal("Test Email", sendMessageToEmail);
        }

        [Fact]
        public async Task TestGetAllMessages()
        {
            await this.messagesService.AddMessageAsync(this.messageInputModel);
            await this.messagesService.AddMessageAsync(this.messageInputModel);
            await this.messagesService.AddMessageAsync(this.messageInputModel);

            var messageCount = this.messagesService.GetAllMessages().Count;

            Assert.Equal(3, messageCount);
        }

        [Fact]
        public async Task TestGetAllSendMessages()
        {
            await this.messagesService.AddSendMessageAsync(this.sendMessageInputModel);
            await this.messagesService.AddSendMessageAsync(this.sendMessageInputModel);

            var sendMessageCount = this.messagesService.GetAllSendMessages().Count;

            Assert.Equal(2, sendMessageCount);
        }

        [Fact]
        public async Task TestGetIsDeletedMessages()
        {
            var firstId = await this.messagesService.AddMessageAsync(this.messageInputModel);
            var secondId = await this.messagesService.AddMessageAsync(this.messageInputModel);

            await this.messagesService.DeleteMessageAsync(firstId);
            await this.messagesService.DeleteMessageAsync(secondId);

            var deletedMessages = this.messagesService.GetIsDeletedMessages();

            Assert.Equal(2, deletedMessages.Count);
        }

        [Fact]
        public async Task TestGetMessageById()
        {
            var id = await this.messagesService.AddMessageAsync(this.messageInputModel);

            var expectMessage = this.messagesService.GetMessageById(id);

            Assert.NotNull(expectMessage);
        }

        [Fact]
        public async Task TestGetSendMessagesById()
        {
            var id = await this.messagesService.AddSendMessageAsync(this.sendMessageInputModel);

            var expectMessage = this.messagesService.GetSendMessageById(id);

            Assert.NotNull(expectMessage);
        }

        [Fact]
        public async Task TestDeleteMessageAsync()
        {
            var id = await this.messagesService.AddMessageAsync(this.messageInputModel);

            await this.messagesService.DeleteMessageAsync(id);

            var expectMessage = this.messageRepository.AllWithDeleted().Where(m => m.Id == id).FirstOrDefault();

            Assert.True(expectMessage.IsDeleted);
        }

        [Fact]
        public async Task TestDeleteSendMessageAsync()
        {
            var id = await this.messagesService.AddSendMessageAsync(this.sendMessageInputModel);

            await this.messagesService.DeleteSendMessageAsync(id);

            var expectMessage = this.sendMessageRepository.AllWithDeleted().Where(m => m.Id == id).FirstOrDefault();

            Assert.True(expectMessage.IsDeleted);
        }

        [Fact]
        public async Task TestRestoreMessageAsync()
        {
            var id = await this.messagesService.AddMessageAsync(this.messageInputModel);

            await this.messagesService.DeleteMessageAsync(id);

            await this.messagesService.RestoreMessageAsync(id);

            var expectMessage = this.messageRepository.All().Where(m => m.Id == id).FirstOrDefault();

            Assert.NotNull(expectMessage);
        }

        [Fact]
        public async Task TestHardDeleteMessageAsync()
        {
            var id = await this.messagesService.AddMessageAsync(this.messageInputModel);

            await this.messagesService.HardDeleteMessageAsync(id);

            var count = this.messageRepository.AllWithDeleted().ToList().Count;

            Assert.Equal(0, count);
        }

        private void InitializeFields()
        {
            this.messageInputModel = new MessageInputModel
            {
                FirstName = "Test First Name",
                LastName = "Test Last Name",
                Email = "Test Email",
                About = "Test About",
                Description = "Test Description",
            };

            this.sendMessageInputModel = new SendMessageInputModel
            {
                About = "Test About",
                Description = "Test Description",
                Email = "Test Email",
            };
        }
    }
}

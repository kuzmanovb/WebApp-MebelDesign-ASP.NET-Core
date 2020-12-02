namespace MebelDesign71.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Messages;

    public class MessagesService : IMessagesService
    {
        private readonly IRepository<Message> messageRepository;

        public MessagesService(IRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<string> AddMessageAsync(MessageInputModel input)
        {
            var newMessage = new Message
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                About = input.About,
                Description = input.Description,
            };

            await this.messageRepository.AddAsync(newMessage);
            await this.messageRepository.SaveChangesAsync();

            return newMessage.Id;
        }

        
        public void SendEmail(MessageInputModel input)
        {
            throw new NotImplementedException();
        }
    }
}

namespace MebelDesign71.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Contacts;

    public class ContactsService : IContactsService
    {
        private readonly IRepository<Message> messageRepository;

        public ContactsService(IRepository<Message> messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task<string> AddMessageAsync(ContactFormViewModel input)
        {
            var newMessage = new Message
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                About = input.About,
                Description = input.Description,
                CreatedOn = DateTime.UtcNow,
            };

            await this.messageRepository.AddAsync(newMessage);
            await this.messageRepository.SaveChangesAsync();

            return newMessage.Id;
        }

        public void SendEmail(ContactFormViewModel input)
        {
            throw new NotImplementedException();
        }
    }
}

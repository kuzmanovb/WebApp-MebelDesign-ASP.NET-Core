namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> dbMessage;

        public MessagesService(IDeletableEntityRepository<Message> dbMessage)
        {
            this.dbMessage = dbMessage;
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

            await this.dbMessage.AddAsync(newMessage);
            await this.dbMessage.SaveChangesAsync();

            return newMessage.Id;
        }

        public ICollection<MessageViewModel> GetAllMessages()
        {
            var allMessage = this.dbMessage.All()
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => new MessageViewModel
                {
                    Id = m.Id,
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email,
                    About = m.About,
                    Description = m.Description,
                    CreateOn = m.CreatedOn.ToShortDateString(),
                    TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                    ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                    IsDeleted = m.IsDeleted,
                }).ToList();

            return allMessage;
        }

        public ICollection<MessageViewModel> GetIsDeletedMessages()
        {
            var allDeletedMessage = this.dbMessage.AllWithDeleted()
                .Where(m => m.IsDeleted == true)
                .OrderByDescending(m => m.CreatedOn)
                 .Select(m => new MessageViewModel
                 {
                     Id = m.Id,
                     FirstName = m.FirstName,
                     LastName = m.LastName,
                     Email = m.Email,
                     About = m.About,
                     Description = m.Description,
                     CreateOn = m.CreatedOn.ToShortDateString(),
                     TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                     ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                     IsDeleted = m.IsDeleted,
                 }).ToList();

            return allDeletedMessage;
        }

        public void SendEmail(MessageInputModel input)
        {
            throw new NotImplementedException();
        }

        private static string CalculateTimeBetweenCreateAndNow(DateTime createOnTime)
        {

            var differentTime = DateTime.UtcNow - createOnTime;
            var differentToMinets = differentTime.TotalMinutes;

            if (differentToMinets > 60 * 24)
            {
                string differentToDays = differentTime.Days.ToString() + " days ago";
                return differentToDays;
            }
            else if (differentToMinets > 60)
            {
                string differentToHours = differentTime.Hours.ToString() + " hours ago";
                return differentToHours;
            }

            return differentToMinets.ToString() + " mins ago";

        }

    }
}

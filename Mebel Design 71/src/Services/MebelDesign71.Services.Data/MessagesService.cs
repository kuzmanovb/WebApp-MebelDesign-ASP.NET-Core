namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;

    public class MessagesService : IMessagesService
    {
        private readonly IDeletableEntityRepository<Message> dbMessage;
        private readonly IDeletableEntityRepository<SendMessage> dbSendMessage;
        private readonly IHtmlSanitizer sanitizer;

        public MessagesService(IDeletableEntityRepository<Message> dbMessage, IDeletableEntityRepository<SendMessage> dbSendMessage, IHtmlSanitizer sanitizer)
        {
            this.dbMessage = dbMessage;
            this.dbSendMessage = dbSendMessage;
            this.sanitizer = sanitizer;
        }

        public async Task<string> AddMessageAsync(MessageInputModel input)
        {
            var newMessage = new Message
            {
                FirstName = this.sanitizer.Sanitize(input.FirstName),
                LastName = this.sanitizer.Sanitize(input.LastName),
                Email = this.sanitizer.Sanitize(input.Email),
                About = this.sanitizer.Sanitize(input.About),
                Description = this.sanitizer.Sanitize(input.Description),
            };

            await this.dbMessage.AddAsync(newMessage);
            await this.dbMessage.SaveChangesAsync();

            return newMessage.Id;
        }

        public async Task<string> AddSendMessageAsync(SendMessageInputModel input)
        {
            var newSendEmail = new SendMessage
            {

                About = this.sanitizer.Sanitize(input.About),
                Description = this.sanitizer.Sanitize(input.Description),
                ToEmail = this.sanitizer.Sanitize(input.Email),
            };

            await this.dbSendMessage.AddAsync(newSendEmail);
            await this.dbSendMessage.SaveChangesAsync();

            return newSendEmail.Id;
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
                    FullName = m.FirstName + " " + m.LastName,
                    Email = m.Email,
                    About = m.About,
                    Description = m.Description,
                    CreateOn = m.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                    TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                    ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                    IsDeleted = m.IsDeleted,
                }).ToList();

            return allMessage;
        }

        public ICollection<SendMessageViewModel> GetAllSendMessages()
        {
            var allSendMessage = this.dbSendMessage.All()
                .OrderByDescending(m => m.CreatedOn)
                 .Select(m => new SendMessageViewModel
                 {
                     Id = m.Id,
                     Email = m.ToEmail,
                     ToMessageId = m.ToMessageId,
                     About = m.About,
                     Description = m.Description,
                     CreateOn = m.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                     TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                     ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                     IsDeleted = m.IsDeleted,
                 }).ToList();
            return allSendMessage;
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
                     FullName = m.FirstName + " " + m.LastName,
                     Email = m.Email,
                     About = m.About,
                     Description = m.Description,
                     CreateOn = m.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                     TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                     ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                     IsDeleted = m.IsDeleted,
                 }).ToList();

            return allDeletedMessage;
        }

        public MessageViewModel GetMessageById(string id)
        {
            var message = this.dbMessage.AllWithDeleted()
                 .Where(m => m.Id == id)
                 .Select(m => new MessageViewModel
                 {
                     Id = m.Id,
                     FirstName = m.FirstName,
                     LastName = m.LastName,
                     FullName = m.FirstName + " " + m.LastName,
                     Email = m.Email,
                     About = m.About,
                     Description = m.Description,
                     CreateOn = m.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                     TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                     ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                     IsDeleted = m.IsDeleted,
                 }).FirstOrDefault();

            return message;
        }


        public SendMessageViewModel GetSendMessageById(string id)
        {
            var allSendMessage = this.dbSendMessage.All()
                .Where(m => m.Id == id)
                 .Select(m => new SendMessageViewModel
                 {
                     Id = m.Id,
                     Email = m.ToEmail,
                     ToMessageId = m.ToMessageId,
                     About = m.About,
                     Description = m.Description,
                     CreateOn = m.CreatedOn.ToString("dd.MM.yyyy HH:mm"),
                     TimeAgo = CalculateTimeBetweenCreateAndNow(m.CreatedOn),
                     ModifiedOn = m.ModifiedOn.GetValueOrDefault().ToString("dd.MM.yyyy"),
                     IsDeleted = m.IsDeleted,
                 }).FirstOrDefault();

            return allSendMessage;
        }


        public async Task DeleteMessageAsync(string id)
        {
            var currentMessage = this.dbMessage.All().FirstOrDefault(m => m.Id == id);
            this.dbMessage.Delete(currentMessage);
            await this.dbMessage.SaveChangesAsync();
        }

        public async Task DeleteSendMessageAsync(string id)
        {
            var currentMessage = this.dbSendMessage.All().FirstOrDefault(m => m.Id == id);
            this.dbSendMessage.Delete(currentMessage);
            await this.dbSendMessage.SaveChangesAsync();
        }


        public async Task RestoreMessageAsync(string id)
        {
            var currentMessage = this.dbMessage.AllWithDeleted().FirstOrDefault(m => m.Id == id);
            this.dbMessage.Undelete(currentMessage);
            await this.dbMessage.SaveChangesAsync();
        }


        public async Task HardDeleteMessageAsync(string id)
        {
            var currentMessage = this.dbMessage.AllWithDeleted().FirstOrDefault(m => m.Id == id);
            this.dbMessage.HardDelete(currentMessage);
            await this.dbMessage.SaveChangesAsync();
        }

        private static string CalculateTimeBetweenCreateAndNow(DateTime createOnTime)
        {
            var differentTime = DateTime.UtcNow - createOnTime;
            var differentToMinets = (int)differentTime.TotalMinutes;

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

namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Messages;

    public interface IMessagesService
    {
        Task<string> AddMessageAsync(MessageInputModel input);

        ICollection<MessageViewModel> GetAllMessages();

        ICollection<MessageViewModel> GetSendMessages();

        ICollection<MessageViewModel> GetIsDeletedMessages();

        MessageViewModel GetMessageById(string id);

        void SendEmail(MessageInputModel input);
    }
}

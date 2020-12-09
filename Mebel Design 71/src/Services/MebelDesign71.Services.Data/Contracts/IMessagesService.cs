namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Messages;

    public interface IMessagesService
    {
        Task<string> AddMessageAsync(MessageInputModel input);

        Task<string> AddSendMessageAsync(SendMessageInputModel input);

        ICollection<MessageViewModel> GetAllMessages();

        ICollection<SendMessageViewModel> GetAllSendMessages();

        ICollection<MessageViewModel> GetIsDeletedMessages();

        MessageViewModel GetMessageById(string id);

        SendMessageViewModel GetSendMessageById(string id);

        Task RestoreMessageAsync(string id);

        Task DeleteMessageAsync(string id);

        Task DeleteSendMessageAsync(string id);

        Task HardDeleteMessageAsync(string id);
    }
}

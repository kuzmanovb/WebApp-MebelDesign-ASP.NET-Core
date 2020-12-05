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

        SendMessageViewModel GetSendMessagesById(string id);

        Task RestoreAsync(string id);

        Task DeleteAsync(string id);

        Task DeleteSendMessageAsync(string id);

        Task HardDeleteAsync(string id);
    }
}

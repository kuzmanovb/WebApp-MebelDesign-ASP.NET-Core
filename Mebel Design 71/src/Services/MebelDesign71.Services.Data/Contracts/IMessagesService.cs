namespace MebelDesign71.Services.Data.Contracts
{
    using MebelDesign71.Web.ViewModels.Messages;
    using System.Threading.Tasks;

    public interface IMessagesService
    {
        Task<string> AddMessageAsync(MessageInputModel input);

        void GetAllMessages();

        void SendEmail(MessageInputModel input);
    }
}

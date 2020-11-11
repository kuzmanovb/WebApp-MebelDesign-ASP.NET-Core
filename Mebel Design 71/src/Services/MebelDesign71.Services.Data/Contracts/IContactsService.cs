namespace MebelDesign71.Services.Data
{
    using MebelDesign71.Web.ViewModels.Contacts;
    using System.Threading.Tasks;

    public interface IContactsService
    {
        Task<string> AddMessageAsync(ContactFormViewModel input);

        void SendEmail(ContactFormViewModel input);
    }
}

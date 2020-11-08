namespace MebelDesign71.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Mapping;

    public class ContactFormViewModel : IMapFrom<Message>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашето име")]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашата фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият email адрес")]
        [Display(Name = "Вашият email адрес")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Моля въведете вашият телефонен номер")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Моля въведете вашето запитване")]
        public string Description { get; set; }

        // ToDo: Implement reCAPTCHA
        public string RecaptchaValue { get; set; }

    }
}

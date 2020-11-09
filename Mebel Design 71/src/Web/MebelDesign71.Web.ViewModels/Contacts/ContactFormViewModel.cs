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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете кратко описание на запитването")]
        [StringLength(100, ErrorMessage = "Темата трябва да е поне {2} и не повече от {1} символа.", MinimumLength = 5)]
        [Display(Name = "Тема на запитването")]
        public string About { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Моля въведете вашето запитване")]
        [StringLength(10000, ErrorMessage = "Запитването трябва да е поне {2} символа.", MinimumLength = 20)]
        [Display(Name = "Запитване")]
        public string Description { get; set; }

        // ToDo: Implement reCAPTCHA
        public string RecaptchaValue { get; set; }

    }
}

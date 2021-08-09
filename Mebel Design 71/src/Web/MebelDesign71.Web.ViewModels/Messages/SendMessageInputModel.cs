namespace MebelDesign71.Web.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;

    public class SendMessageInputModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете email адрес")]
        [Display(Name = "Email адрес")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете тема на съобщение")]
        [StringLength(100, ErrorMessage = "Темата на съобщението трябва да е поне {2} и не повече от {1} символа.", MinimumLength = 5)]
        [Display(Name = "Тема на съобщението")]
        public string About { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашето запитване")]
        [StringLength(10000, ErrorMessage = "Съобщението трябва да е поне {2}  и не повече от {1} символа.", MinimumLength = 10)]
        [Display(Name = "Съобщение")]
        public string Description { get; set; }
    }
}

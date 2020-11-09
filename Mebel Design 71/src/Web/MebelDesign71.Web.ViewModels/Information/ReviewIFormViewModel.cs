namespace MebelDesign71.Web.ViewModels.Information
{
    using MebelDesign71.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ReviewIFormViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашето име")]
        [StringLength(30, ErrorMessage = "Името трябва да бъде по-малко от {1}.")]
        [Display(Name = "Вашето име")]
        public string Name { get; set; }

        [Display(Name = "Профилна снимка")]
        public FileOnFileSystem ImageId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият отзив")]
        [StringLength(1000, ErrorMessage = "Вашият отзив трябва да бъде не по-малко от {1} символа и не по-голям от {2} символа.")]
        [Display(Name = "Вашият отзив")]
        public string Description { get; set; }

    }
}

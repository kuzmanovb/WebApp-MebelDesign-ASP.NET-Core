namespace MebelDesign71.Web.ViewModels.Information
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class ReviewInputModel
    {
        public string UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашето име")]
        [StringLength(30, ErrorMessage = "Името трябва да бъде по-малко от {1}.")]
        [Display(Name = "Вашето име")]
        public string Name { get; set; }

        [Display(Name = "Профилна снимка")]
        [FileSizeValidationAttribute(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Размерът на файла на изображението трябва да е по-малък от 5 MB")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Снимката трябва да бъде в jpg, jpeg или png фомат.")]
        public IFormFile ImageFile { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият отзив")]
        [StringLength(1000, MinimumLength =20, ErrorMessage = "Вашият отзив трябва да бъде не по-малко от {2} символа и не по-голям от {1} символа.")]
        [Display(Name = "Вашият отзив")]
        public string Description { get; set; }
    }
}

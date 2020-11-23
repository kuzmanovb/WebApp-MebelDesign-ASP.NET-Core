namespace MebelDesign71.Web.ViewModels.Service
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class ServiceInputModel
    {
        public int? Id { get; set; }

        // ToDo: Escape special symbol to name
        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Представяне на услугата")]
        public string Description { get; set; }

        [Display(Name = "Профилна снимка")]
        [ImageSizeValidatorForReiewAttribute(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Размерът на файла на изображението трябва да е по-малък от 5 MB")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile HeadImage { get; set; }

        // ToDo: Validate size and extension
        [Display(Name = "Прикачен файл")]
        public IFormFile Document { get; set; }

        public string ImagePath { get; set; }

        public string DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string IsDeleted { get; set; }
    }
}

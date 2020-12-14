namespace MebelDesign71.Web.ViewModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class ProjectInputModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Представяне на проекта")]
        public string Description { get; set; }

        [Display(Name = "Снимка на проекта")]
        [FileSizeValidationAttribute(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Размерът на файла на изображението трябва да е по-малък от 5 MB")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Формата на документа трябва да бъде в jpg, jpeg, png, doc, docx, xls, xlsx, txt или pdf фомат.")]
        public IFormFile HeadImage { get; set; }

        public string ImagePath { get; set; }
    }
}

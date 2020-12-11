namespace MebelDesign71.Web.ViewModels.Service
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class ServiceInputModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Представяне на услугата")]
        public string Description { get; set; }

        [Display(Name = "Профилна снимка")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Снимката трябва да бъде в jpg, jpeg или png фомат.")]
        [FileSizeValidationAttribute(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Размерът на файла на изображението трябва да е по-малък от 5 MB")]
        public IFormFile HeadImage { get; set; }

        [Display(Name = "Прикачен файл")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt ", ".pdf" },
                           ErrorMessage = "Формата на документа трябва да бъде в jpg, jpeg, png, doc, docx, xls, xlsx, txt или pdf фомат.")]
        [FileSizeValidationAttribute(sizeInBytes: 2 * 1024 * 1024, ErrorMessage = "Размерът на файла трябва да е по-малък от 2 MB")]
        public IFormFile Document { get; set; }

        public string ImagePath { get; set; }

        public string DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string IsDeleted { get; set; }
    }
}

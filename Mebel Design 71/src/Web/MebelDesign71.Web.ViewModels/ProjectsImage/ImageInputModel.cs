namespace MebelDesign71.Web.ViewModels.ProjectsImage
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class ImageInputModel
    {
        public int ProjectId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name ="Снимка")]
        [FileSizeValidationAttribute(sizeInBytes: 5 * 1024 * 1024, ErrorMessage = "Размерът на файла на изображението трябва да е по-малък от 5 MB")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Формата на документа трябва да бъде в jpg, jpeg, png, doc, docx, xls, xlsx, txt или pdf фомат.")]
        public IFormFile ImageFile { get; set; }

    }
}

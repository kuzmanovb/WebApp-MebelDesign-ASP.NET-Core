namespace MebelDesign71.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;

    public class OrderInputModel
    {
        public OrderInputModel()
        {
            this.Documents = new List<IFormFile>();
        }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Моля изберете услуга")]
        public int ServiceId { get; set; }

        [StringLength(2000, ErrorMessage = "Текста трябва да пъде по-малко от 2000 символа.")]
        public string Description { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt ", ".pdf" },
                           ErrorMessage = "Формата на документа трябва да бъде в jpg, jpeg, png, doc, docx, xls, xlsx, txt или pdf фомат.")]
        [FileSizeValidationAttribute(sizeInBytes: 2 * 1024 * 1024, ErrorMessage = "Размерът на файла трябва да е по-малък от 2 MB")]
        public ICollection<IFormFile> Documents { get; set; }

    }
}

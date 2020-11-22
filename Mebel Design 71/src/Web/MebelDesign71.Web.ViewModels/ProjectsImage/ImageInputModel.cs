namespace MebelDesign71.Web.ViewModels.ProjectsImage
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ImageInputModel
    {
        public int ProjectId { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name ="Снимка")]
        public IFormFile ImageFile { get; set; }

    }
}

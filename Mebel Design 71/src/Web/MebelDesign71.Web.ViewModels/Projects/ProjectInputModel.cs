namespace MebelDesign71.Web.ViewModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ProjectInputModel
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name ="Име")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Представяне на проекта")]
        public string Description { get; set; }

        public IFormFile HeadImage { get; set; }
    }
}

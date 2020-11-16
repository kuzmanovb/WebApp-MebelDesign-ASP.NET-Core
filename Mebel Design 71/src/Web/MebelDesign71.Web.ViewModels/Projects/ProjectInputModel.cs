namespace MebelDesign71.Web.ViewModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ProjectInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile HeadImage { get; set; }
    }
}

namespace MebelDesign71.Web.ViewModels.ProjectsImage
{
    using Microsoft.AspNetCore.Http;

    public class ImageInputModel
    {
        public int ProjectId { get; set; }

        public string Description { get; set; }

        public IFormFile ImageFile { get; set; }

    }
}

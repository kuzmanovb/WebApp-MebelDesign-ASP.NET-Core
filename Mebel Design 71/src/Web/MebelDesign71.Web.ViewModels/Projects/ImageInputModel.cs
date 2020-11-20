namespace MebelDesign71.Web.ViewModels.Projects
{
    using Microsoft.AspNetCore.Http;

    public class ImageInputModel
    {
        public int ProjectId { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

    }
}

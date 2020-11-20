namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    public class AdminProjectsGalleryController : AdministrationController
    {
        private readonly IProjectsService projectsService;

        public AdminProjectsGalleryController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public IActionResult Index()
        {
            this.ViewData["AllProjects"] = this.projectsService.GetAllProjects();

            return this.View();
        }

        public IActionResult Gallery(int id)
        {
            return this.View();
        }

        public IActionResult AddImage(int id)
        {
            this.ViewData["id"] = id;
            return this.View();

        }

        [HttpPost]
        public IActionResult AddImage(ImageInputModel input)
        {
            return this.View();

        }
    }
}

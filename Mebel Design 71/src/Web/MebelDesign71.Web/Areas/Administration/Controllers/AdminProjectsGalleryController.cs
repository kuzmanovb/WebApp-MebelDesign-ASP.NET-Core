namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.Controllers;
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

        public IActionResult Gallery()
        {
            return this.View();
        }
    }
}

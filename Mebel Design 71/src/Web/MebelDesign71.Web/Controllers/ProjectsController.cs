namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : Controller
    {
        private readonly IProjectsService projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this.ViewData["projects"] = this.projectsService.GetAllProjects();

            return this.View();
        }

        public IActionResult CurrentProject(string category)
        {
            return this.View();
        }
    }
}

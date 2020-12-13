namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectsController : BaseController
    {
        private readonly IProjectsService projectsService;
        private readonly IProjectsGalleryService projectsGalleryService;

        public ProjectsController(IProjectsService projectsService, IProjectsGalleryService projectsGalleryService)
        {
            this.projectsService = projectsService;
            this.projectsGalleryService = projectsGalleryService;
        }

        public IActionResult Index()
        {
            this.ViewData["projects"] = this.projectsService.GetAllProjects();

            return this.View();
        }

        public async Task<IActionResult> CurrentProject(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("/");
            }

            var currentProject = await this.projectsService.GetProjectByIdAsync(id);

            return this.View(currentProject);
        }

        public async Task<IActionResult> Gallery(int projectId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("/");
            }

            var currentProject = await this.projectsService.GetProjectByIdAsync(projectId);

            this.ViewData["gallery"] = await this.projectsGalleryService.GetGalleryAsync(projectId);
            this.ViewData["projectName"] = currentProject.Name;
            this.ViewData["projectDescription"] = currentProject.Description;

            return this.View();
        }
    }
}

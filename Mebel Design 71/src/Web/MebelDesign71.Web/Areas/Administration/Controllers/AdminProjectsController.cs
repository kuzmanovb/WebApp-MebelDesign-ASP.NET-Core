namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    public class AdminProjectsController : AdministrationController
    {
        private readonly IProjectsService projectsService;

        public AdminProjectsController(IProjectsService projectsService)
        {
            this.projectsService = projectsService;
        }

        public IActionResult Index()
        {
            var allProjects = this.projectsService.GetAllProjectsWithDeleted();

            this.ViewData["AllProjects"] = allProjects;

            return this.View();
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            if (input.HeadImage == null)
            {
                return this.View(input);
            }

            var id = await this.projectsService.CreateProject(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProject(int id)
        {
            var currentProject = await this.projectsService.GetProjectById(id);

            return this.View(currentProject);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProject(ProjectInputModel input)
        {
            await this.projectsService.UpdateProject(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeIsDeleted(int id)
        {
            await this.projectsService.ChangeIsDeleteProject(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete (int id)
        {
            await this.projectsService.DeleteProject(id);

            return this.RedirectToAction("Index");
        }
    }
}
namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    public class AdminProjectsController : AdministrationController
    {
        private readonly IProjectService projectService;

        public AdminProjectsController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public IActionResult Index()
        {
            var allProjects = this.projectService.GetAllProjects();

            this.ViewData["AllProjects"] = allProjects;

            return this.View();

        }

        public IActionResult CreateProject()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectInputModel input)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var id = this.projectService.CreateProject(input);

            return this.RedirectToAction("Index");
        }

        public IActionResult UpdateProject(int id)
        {


            

            return this.RedirectToAction("Index");
        }
    }
}
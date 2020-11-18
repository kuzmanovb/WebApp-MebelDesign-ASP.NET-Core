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

    public class ProjectsController : AdministrationController
    {
        private readonly IProjectService projectService;

        public ProjectsController(IProjectService projectService)
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
    }
}
namespace MebelDesign71.Web.Areas.Administration.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("Api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> dbProject;

        public ProjectController(IDeletableEntityRepository<Project> dbProject)
        {
            this.dbProject = dbProject;
        }

        public IEnumerable<ProjectViewModel> GetAllProjects()
        {
            var allProjects = this.dbProject.AllAsNoTracking()
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted,
                }).ToList();

            return allProjects;
        }


        public Task<IActionResult> GetProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> CreateProject(ProjectInputModel input)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> UpdateProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

    }
}

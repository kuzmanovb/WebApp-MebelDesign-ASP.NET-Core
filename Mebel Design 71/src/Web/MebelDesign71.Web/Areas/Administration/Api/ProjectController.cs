namespace MebelDesign71.Web.Areas.Administration.Api
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("Api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> dbProject;
        private readonly IFilesService filesService;

        public ProjectController(IDeletableEntityRepository<Project> dbProject, IFilesService filesService)
        {
            this.dbProject = dbProject;
            this.filesService = filesService;
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

        public IActionResult GetProjectById(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentProject = this.dbProject.All().Where(p => p.Id == id).FirstOrDefault();

            if (currentProject == null)
            {
                return this.NotFound();
            }

            return this.Ok(currentProject);
        }

        public async Task<IActionResult> CreateProject(ProjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images/projecImages");

            var newProject = new Project
            {
                Name = input.Name,
                Description = input.Description,
                HeadImageId = imageId,
            };

            await this.dbProject.AddAsync(newProject);
            await this.dbProject.SaveChangesAsync();

            return this.NoContent();
        }

        public async Task<IActionResult> UpdateProject(ProjectInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentProject = this.dbProject.All().Where(p => p.Name == input.Name).FirstOrDefault();

            if (currentProject == null)
            {
                return this.NotFound();
            }

            if (input.HeadImage != null)
            {
                var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images/projecImages");
                currentProject.HeadImageId = imageId;
            }

            currentProject.Name = input.Name;
            currentProject.Description = input.Description;

            this.dbProject.Update(currentProject);
            await this.dbProject.SaveChangesAsync();

            return this.NoContent();
        }

        public async Task<IActionResult> ChangeIsDeleteProject(int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var currentProject = this.dbProject.All().Where(p => p.Id == id).FirstOrDefault();

            if (currentProject == null)
            {
                return this.NotFound();
            }

            if (currentProject.IsDeleted == true)
            {
                currentProject.IsDeleted = false;
            }
            else
            {
                currentProject.IsDeleted = true;
            }

            this.dbProject.Update(currentProject);
            await this.dbProject.SaveChangesAsync();

            return this.NoContent();
        }
    }
}

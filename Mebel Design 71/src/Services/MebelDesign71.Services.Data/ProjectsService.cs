namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsService : IProjectService
    {
        private readonly IDeletableEntityRepository<Project> dbProject;
        private readonly IFilesService filesService;

        public ProjectsService(IDeletableEntityRepository<Project> dbProject, IFilesService filesService)
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
                    IsDeleted = p.IsDeleted == false ? "ДА" : "НЕ",
                    HeadImage = p.HeadImage.File.FilePath,
                }).ToList();

            return allProjects;
        }

        public async Task<ProjectViewModel> GetProjectById(int id)
        {

            var currentProject = await this.dbProject.All().Where(p => p.Id == id)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    HeadImage = p.HeadImage.File.FilePath,
                    IsDeleted = p.IsDeleted == false ? "ДА" : "НЕ",
                })
                .FirstOrDefaultAsync();

            return currentProject;
        }

        public async Task<int> CreateProject(ProjectInputModel input)
        {

            var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images/projecImages");

            var newProject = new Project
            {
                Name = input.Name,
                Description = input.Description,
                HeadImageId = imageId,
            };

            await this.dbProject.AddAsync(newProject);
            await this.dbProject.SaveChangesAsync();

            return newProject.Id;

        }

        public async Task UpdateProject(ProjectInputModel input)
        {

            var currentProject = this.dbProject.All().Where(p => p.Name == input.Name).FirstOrDefault();


            if (input.HeadImage != null)
            {
                var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images/projecImages");
                currentProject.HeadImageId = imageId;
            }

            currentProject.Name = input.Name;
            currentProject.Description = input.Description;

            this.dbProject.Update(currentProject);
            await this.dbProject.SaveChangesAsync();

        }

        public async Task ChangeIsDeleteProject(int id)
        {

            var currentProject = this.dbProject.All().Where(p => p.Id == id).FirstOrDefault();

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

        }
    }
}

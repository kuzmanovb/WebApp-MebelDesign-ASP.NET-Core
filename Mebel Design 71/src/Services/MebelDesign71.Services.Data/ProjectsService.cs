namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsService : IProjectsService
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
                    HeadImage = RenameFilePath(p.HeadImage.FilePath),
                }).ToList();

            return allProjects;
        }

        public IEnumerable<ProjectViewModel> GetAllProjectsWithDeleted()
        {
            var allProjects = this.dbProject.AllAsNoTrackingWithDeleted()
                .OrderBy(p => p.IsDeleted ? 1 : 0)
                .Select(p => new ProjectViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    IsDeleted = p.IsDeleted == false ? "ДА" : "НЕ",
                    HeadImage = RenameFilePath(p.HeadImage.FilePath),
                }).ToList();

            return allProjects;
        }

        public async Task<ProjectInputModel> GetProjectById(int id)
        {

            var currentProject = await this.dbProject.AllWithDeleted().Where(p => p.Id == id)
                .Select(p => new ProjectInputModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImagePath = RenameFilePath(p.HeadImage.FilePath),
                })
                .FirstOrDefaultAsync();

            return currentProject;
        }

        public async Task<int> CreateProject(ProjectInputModel input)
        {

            var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images\\projecImages", "Project Hade Image ");

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

            var currentProject = this.dbProject.All().Where(p => p.Id == input.Id).FirstOrDefault();

            if (input.HeadImage != null)
            {
                var imageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images/projecImages");
                currentProject.HeadImageId = imageId;
            }

            if (currentProject.Name != input.Name)
            {
                currentProject.Name = input.Name;
            }

            if (currentProject.Description != input.Description)
            {
                currentProject.Description = input.Description;
            }

            this.dbProject.Update(currentProject);
            await this.dbProject.SaveChangesAsync();
        }

        public async Task ChangeIsDeleteProject(int id)
        {

            var currentProject = this.dbProject.AllWithDeleted().Where(p => p.Id == id).FirstOrDefault();

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

        private static string RenameFilePath(string fullPath)
        {
            var oldString = "\\";
            var newString = "/";
            var replaceSlashInFullPath = fullPath.Replace(oldString, newString);

            var getIndexStartWwwRoot = fullPath.IndexOf("wwwroot");
            var lengthWwwroot = "wwwroot".Length;

            if (getIndexStartWwwRoot >= 0)
            {

                var pathForView = "~" + replaceSlashInFullPath.Substring(getIndexStartWwwRoot + lengthWwwroot);
                return pathForView;
            }

            return replaceSlashInFullPath;
        }

    }
}

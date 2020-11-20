namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.ProjectsImage;
    using Microsoft.EntityFrameworkCore;

    public class ProjectsGalleryService : IProjectsGalleryService
    {
        private readonly IRepository<ImageToProject> dbImageToProject;
        private readonly IRepository<FileOnFileSystem> dbFileOnFilesystem;
        private readonly IFilesService filesService;
        private readonly IProjectsService projectsService;

        public ProjectsGalleryService(IRepository<ImageToProject> dbImageToProject, IRepository<FileOnFileSystem> dbFileOnFilesystem, IFilesService filesService, IProjectsService projectsService)
        {
            this.dbImageToProject = dbImageToProject;
            this.dbFileOnFilesystem = dbFileOnFilesystem;
            this.filesService = filesService;
            this.projectsService = projectsService;
        }

        public async Task<int> AddImageToGallery(ImageInputModel input)
        {
            var currentProject = await this.projectsService.GetProjectById(input.ProjectId);

            var projectName = currentProject.Name;

            var imageId = await this.filesService.UploadToFileSystem(input.ImageFile, "images\\projecImages\\" + projectName, "ImageTo" + projectName + "Gallery");

            var newImageToProject = new ImageToProject
            {
                FileId = imageId,
                Description = input.Description,
                ProjectId = input.ProjectId,

            };

            await this.dbImageToProject.AddAsync(newImageToProject);
            await this.dbImageToProject.SaveChangesAsync();

            return newImageToProject.Id;
        }

        public async Task<ICollection<ViewImageModel>> GetGallery(int id)
        {
            var projectGallery = await this.dbImageToProject.All()
                .Where(i => i.ProjectId == id)
                .Select(i => new ViewImageModel
                {
                    Id = i.Id,
                    Description = i.Description,
                    ImageFullPath = i.File.FilePath,
                    ImagePath = RenameFilePath(i.File.FilePath),
                }).ToListAsync();

            return projectGallery;
        }

        public async Task DeleteImage(int id)
        {
            var currentImage = this.dbImageToProject.All().Where(i => i.Id == id).FirstOrDefault();
            var fileId = currentImage.FileId;

            this.dbImageToProject.Delete(currentImage);
            await this.dbImageToProject.SaveChangesAsync();

            var currentFile = await this.filesService.DeleteFileFromFileSystem(fileId);
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

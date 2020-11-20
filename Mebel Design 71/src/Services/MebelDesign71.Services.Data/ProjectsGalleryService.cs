namespace MebelDesign71.Services.Data
{
    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;
    using System.Threading.Tasks;

    public class GalleriesService : IProjectsGalleryService
    {
        private readonly IRepository<ImageToProject> dbImageToProject;
        private readonly IFilesService filesService;
        private readonly IProjectsService projectsService;

        public GalleriesService(IRepository<ImageToProject> dbImageToProject, IFilesService filesService, IProjectsService projectsService)
        {
            this.dbImageToProject = dbImageToProject;
            this.filesService = filesService;
            this.projectsService = projectsService;
        }

        public async Task<int> AddImageToGallery(ImageInputModel input)
        {
            var currentProject = await this.projectsService.GetProjectById(input.ProjectId);

            var projectName = currentProject.Name;

            var imageId = await this.filesService.UploadToFileSystem(input.ImageFile, "images\\projecImages", "ImageTo" + projectName + "Gallery");

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

        public Task DeleteImage(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task GetGallery(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

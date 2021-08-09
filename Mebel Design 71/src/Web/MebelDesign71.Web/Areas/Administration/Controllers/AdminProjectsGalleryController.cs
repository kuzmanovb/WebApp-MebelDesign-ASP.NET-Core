namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.ProjectsImage;
    using Microsoft.AspNetCore.Mvc;

    public class AdminProjectsGalleryController : AdministrationController
    {
        private readonly IProjectsService projectsService;
        private readonly IProjectsGalleryService projectsGalleryService;

        public AdminProjectsGalleryController(IProjectsService projectsService, IProjectsGalleryService projectsGalleryService)
        {
            this.projectsService = projectsService;
            this.projectsGalleryService = projectsGalleryService;
        }

        public IActionResult Index()
        {
            this.ViewData["AllProjects"] = this.projectsService.GetAllProjects();

            return this.View();
        }

        public async Task<IActionResult> Gallery(int id)
        {
            var currentProject = await this.projectsService.GetProjectByIdAsync(id);
            this.ViewData["projectId"] = id;
            this.ViewData["projectName"] = currentProject.Name;
            var galery = await this.projectsGalleryService.GetGalleryAsync(id);
            this.ViewData["projectGalery"] = galery;

            return this.View();
        }

        public IActionResult AddImage(int id)
        {
            this.ViewData["id"] = id;
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddImage(ImageInputModel input)
        {
            if (!this.ModelState.IsValid || input.ImageFile == null)
            {
                this.ViewData["id"] = input.ProjectId;
                return this.View();
            }

            await this.projectsGalleryService.AddImageToGalleryAsync(input);

            return this.RedirectToAction("Gallery", new { id = input.ProjectId});
        }

        public async Task<IActionResult> DeleteImage(int imageId, int projectId)
        {
            await this.projectsGalleryService.DeleteImageAsync(imageId);

            return this.RedirectToAction("Gallery", new { id = projectId });
        }
    }
}

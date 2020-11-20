namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.ProjectsImage;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
            var currentProject = await this.projectsService.GetProjectById(id);
            this.ViewData["projectId"] = id;
            this.ViewData["projectName"] = currentProject.Name;
            var galery = await this.projectsGalleryService.GetGallery(id);
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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.projectsGalleryService.AddImageToGallery(input);

            return this.RedirectToAction("Gallery", new { id = input.ProjectId});
        }

        public async Task<IActionResult> DeleteImage(int imageId, int projectId)
        {
            await this.projectsGalleryService.DeleteImage(imageId);

            return this.RedirectToAction("Gallery", new { id = projectId });
        }
    }
}

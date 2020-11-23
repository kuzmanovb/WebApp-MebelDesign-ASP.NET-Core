namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using MebelDesign71.Services.Data;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Service;
    using Microsoft.AspNetCore.Mvc;

    public class AdminServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;
        private readonly IFilesService filesService;

        public AdminServicesController(IServicesService servicesService, IFilesService filesService)
        {
            this.servicesService = servicesService;
            this.filesService = filesService;
        }

        public IActionResult Index()
        {
            var allService = this.servicesService.GetAllServiceWithDeleted();

            this.ViewData["AllService"] = allService;

            return this.View();
        }

        public IActionResult CreateService()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(ServiceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.servicesService.CreateService(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadDocument(string id)
        {
            var file = await this.filesService.GetFileByIdFromFileSystem(id);

            if (file == null)
            {
                return null;
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return this.File(memory, file.FileType, file.Name + file.Extension);
        }
    }
}

namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using MebelDesign71.Data;
    using MebelDesign71.Services.Data;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Service;
    using Microsoft.AspNetCore.Mvc;

    public class AdminServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;
        private readonly IFilesService filesService;
        private readonly ApplicationDbContext db;

        public AdminServicesController(IServicesService servicesService, IFilesService filesService, ApplicationDbContext db)
        {
            this.servicesService = servicesService;
            this.filesService = filesService;
            this.db = db;
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

        public async Task<IActionResult> UpdateService(int id)
        {
            var currentService = await this.servicesService.GetServiceById(id);

            return this.View(currentService);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceInputModel input)
        {
            await this.servicesService.UpdateService(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var currentService = this.db.Services.FirstOrDefault(p => p.Id == id);
            this.db.Services.Remove(currentService);
            await this.db.SaveChangesAsync();

            await this.filesService.DeleteFileFromFileSystem(currentService.HeadImageId);
            if (currentService.DocumentId != null)
            {
                await this.filesService.DeleteFileFromFileSystem(currentService.DocumentId);
            }

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

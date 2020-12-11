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
        private readonly IOrdersService ordersService;

        public AdminServicesController(IServicesService servicesService, IFilesService filesService, IOrdersService ordersService)
        {
            this.servicesService = servicesService;
            this.filesService = filesService;
            this.ordersService = ordersService;
        }

        public IActionResult Index()
        {
            var allService = this.servicesService.GetAllServiceWithDeleted();
            var orders = this.ordersService.GetAllOrders();

            this.ViewData["AllService"] = allService;
            this.ViewData["Orders"] = orders;

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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.servicesService.UpdateService(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeIsDeleted(int id)
        {
            await this.servicesService.ChangeIsDeleteService(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.servicesService.Delete(id);

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

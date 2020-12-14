namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data;
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;

    public class ServicesController : BaseController
    {
        private readonly IServicesService servicesService;
        private readonly IFilesService filesService;

        public ServicesController(IServicesService servicesService, IFilesService filesService)
        {
            this.servicesService = servicesService;
            this.filesService = filesService;
        }

        public IActionResult Index()
        {

            this.ViewData["services"] = this.servicesService.GetAllService();

            return this.View();
        }

        public async Task<IActionResult> CurrentService(int id)
        {
            var currentService = await this.servicesService.GetServiceByIdForViewAsync(id);

            return this.View(currentService);
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

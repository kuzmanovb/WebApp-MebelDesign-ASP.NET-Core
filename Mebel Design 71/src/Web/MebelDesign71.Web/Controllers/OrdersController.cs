namespace MebelDesign71.Web.Controllers
{
    using System.IO;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IOrdersService ordersService;
        private readonly IServicesService servicesService;
        private readonly IFilesService filesService;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IOrdersService ordersService, IServicesService servicesService, IFilesService filesService, UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.servicesService = servicesService;
            this.filesService = filesService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            this.ViewData["orders"] = this.ordersService.GetOrdersByUserId(this.userManager.GetUserId(this.User));
            return this.View();

        }

        public IActionResult OrderForm()
        {
            this.ViewData["services"] = this.servicesService.GetAllService();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderForm(OrderInputModel input)
        {

            if (!this.ModelState.IsValid)
            {
                this.ViewData["services"] = this.servicesService.GetAllService();
                this.ModelState.AddModelError("serviceId", "Трябва да изберете услуга от падащото меню");
                return this.View(input);
            }

            await this.ordersService.AddOrder(input);

            return this.RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var order = this.ordersService.GetOrderById(id);

            return this.View(order);
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

        public async Task<IActionResult> DeletedOrder(string id)
        {
            await this.ordersService.DeletedOrder(id);

            return this.RedirectToAction("Index");
        }
    }
}

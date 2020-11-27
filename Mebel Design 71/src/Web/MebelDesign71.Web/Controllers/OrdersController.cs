namespace MebelDesign71.Web.Controllers
{
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
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
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(IOrdersService ordersService, IServicesService servicesService, UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.servicesService = servicesService;
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
                return this.View(input);
            }

            await this.ordersService.AddOrder(input);

            return this.RedirectToAction("Index");
        }


        public async Task<IActionResult> DeletedOrder(string id)
        {
            await this.ordersService.DeletedOrder(id);

            return this.RedirectToAction("Index");
        }
    }
}

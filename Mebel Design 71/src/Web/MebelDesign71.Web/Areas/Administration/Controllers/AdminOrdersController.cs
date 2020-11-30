namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class AdminOrdersController : AdministrationController
    {
        private readonly IOrdersService ordersService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminOrdersController(IOrdersService ordersService, UserManager<ApplicationUser> userManager)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            this.ViewData["users"] = await this.userManager.Users.ToListAsync();
            this.ViewData["orders"] = this.ordersService.GetAllOrders();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            this.ViewData["users"] = await this.userManager.Users.ToListAsync();
            this.ViewData["orders"] = this.ordersService.GetOrdersByUserId(id);
            return this.View();
        }

        public IActionResult UpdateOrder(string id)
        {
            var order = this.ordersService.GetOrderById(id);

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(OrderViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.ordersService.UpdateOrder(input);

            return this.RedirectToAction("Index");
        }
    }
}

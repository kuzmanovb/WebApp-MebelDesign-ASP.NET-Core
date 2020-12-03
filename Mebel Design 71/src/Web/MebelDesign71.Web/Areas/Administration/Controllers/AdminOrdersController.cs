namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        public async Task<IActionResult> Index(string id, string sortby)
        {
            if (id != null)
            {
                this.ViewData["users"] = await this.userManager.Users.ToListAsync();
                this.ViewData["orders"] = this.ordersService.GetOrdersByUserId(id);
                this.ViewData["userId"] = id;
            }

            if (sortby != null)
            {
                var sortbyArray = sortby.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var sortParametar = sortbyArray[0];

                ICollection<OrderViewModel> orders = null;

                if (sortbyArray.Length == 1)
                {
                    orders = this.ordersService.GetAllOrders();
                }
                else if (sortbyArray.Length == 2)
                {
                    var userId = sortbyArray[1];
                    orders = this.ordersService.GetOrdersByUserId(userId);
                    this.ViewData["userId"] = userId;
                }

                switch (sortParametar)
                {
                    case "Service": orders = orders.OrderByDescending(o => o.ServiceId).ToList(); break;
                    case "ProgressUp": orders = orders.OrderBy(o => o.Progress).ToList(); break;
                    case "ProgressDown": orders = orders.OrderByDescending(o => o.Progress).ToList(); break;
                    case "DateUp": orders = orders.OrderBy(o => o.CreatedOn).ToList(); break;
                    case "DateDown": orders = orders.OrderByDescending(o => o.CreatedOn).ToList(); break;
                }

                this.ViewData["users"] = await this.userManager.Users.ToListAsync();
                this.ViewData["orders"] = orders;
            }

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

﻿namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        private readonly IFilesService filesService;

        public AdminOrdersController(IOrdersService ordersService, UserManager<ApplicationUser> userManager, IFilesService filesService)
        {
            this.ordersService = ordersService;
            this.userManager = userManager;
            this.filesService = filesService;
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

            await this.ordersService.UpdateOrderAsync(input);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> DownloadDocument(string id)
        {
            var file = await this.filesService.GetFileByIdFromFileSystemAsync(id);

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

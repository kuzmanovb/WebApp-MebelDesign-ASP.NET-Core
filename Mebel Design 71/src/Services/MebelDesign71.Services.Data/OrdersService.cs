﻿namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.Infrastructure;
    using MebelDesign71.Web.ViewModels.Orders;

    using Microsoft.AspNetCore.Http;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<OrderDocument> dbOrderDocument;
        private readonly IDeletableEntityRepository<Order> dbOrder;
        private readonly IFilesService filesService;
        private readonly IHtmlSanitizer sanitizer;

        public OrdersService(IDeletableEntityRepository<OrderDocument> dbOrderDocument, IDeletableEntityRepository<Order> dbOrder, IFilesService filesService, IHtmlSanitizer sanitizer)
        {
            this.dbOrderDocument = dbOrderDocument;
            this.dbOrder = dbOrder;
            this.filesService = filesService;
            this.sanitizer = sanitizer;
        }

        public async Task<string> AddDocumentToOrderAsync(IFormFile document, string orderId, string userId, string orderNumber)
        {
            var fileId = await this.filesService.UploadToFileSystemAsync(document, "documents\\service\\orders\\" + orderNumber, "Service Document");
            var newUserDocument = new OrderDocument
            {
                UserId = userId,
                DocumentId = fileId,
                OrderId = orderId,
            };

            await this.dbOrderDocument.AddAsync(newUserDocument);
            await this.dbOrderDocument.SaveChangesAsync();

            return newUserDocument.Id;
        }

        public async Task<string> AddOrderAsync(OrderInputModel input)
        {
            var newOrder = new Order
            {
                ServiceId = input.ServiceId,
                Description = this.sanitizer.Sanitize(input.Description),
                UserId = input.UserId,
                Number = DateTime.UtcNow.ToString("yMdhms"),
            };

            await this.dbOrder.AddAsync(newOrder);
            await this.dbOrder.SaveChangesAsync();

            foreach (var document in input.Documents)
            {
                await this.AddDocumentToOrderAsync(document, newOrder.Id, input.UserId, newOrder.Number);
            }

            return newOrder.Id;
        }

        public ICollection<OrderViewModel> GetAllOrders()
        {
            var allOrders = this.dbOrder.All()
                 .OrderByDescending(o => o.CreatedOn)
                 .Select(o => new OrderViewModel
                 {
                     OrderId = o.Id,
                     Number = o.Number,
                     UserId = o.UserId,
                     UserEmail = o.User.Email,
                     Price = o.Price,
                     Description = o.Description,
                     CreatedOn = o.CreatedOn.ToShortDateString(),
                     Progress = o.Progress,
                     ProgressDisplay = o.Progress.GetDescription<Progress>(),
                     ServiceId = o.ServiceId ?? default(int),
                     ServiceName = o.Service.Name,
                     Documents = o.Documents.Select(d => new DocumentViewModel { Id = d.Document.Id, Name = d.Document.Name }).ToList(),
                 }).ToList();

            return allOrders;
        }

        public ICollection<OrderViewModel> GetOrdersByUserId(string userId)
        {
            var allOrdersToUser = this.dbOrder.All()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Id,
                    Number = o.Number,
                    UserId = o.UserId,
                    UserEmail = o.User.Email,
                    Price = o.Price,
                    Description = o.Description,
                    CreatedOn = o.CreatedOn.ToShortDateString(),
                    Progress = o.Progress,
                    ProgressDisplay = o.Progress.GetDescription<Progress>(),
                    ServiceId = o.ServiceId ?? default(int),
                    ServiceName = o.Service.Name,
                    Documents = o.Documents.Select(d => new DocumentViewModel { Id = d.Document.Id, Name = d.Document.Name }).ToList(),
                }).ToList();

            return allOrdersToUser;
        }

        public OrderViewModel GetOrderById(string orderId)
        {
            var currentOrder = this.dbOrder.All()
                 .Where(o => o.Id == orderId)
                 .Select(o => new OrderViewModel
                 {
                     OrderId = o.Id,
                     Number = o.Number,
                     UserId = o.UserId,
                     UserEmail = o.User.Email,
                     Price = o.Price,
                     Description = o.Description,
                     CreatedOn = o.CreatedOn.ToShortDateString(),
                     Progress = o.Progress,
                     ProgressDisplay = o.Progress.GetDescription<Progress>(),
                     ServiceId = o.ServiceId ?? default(int),
                     ServiceName = o.Service.Name,
                     Documents = o.Documents.Select(d => new DocumentViewModel { Id = d.Document.Id, Name = d.Document.Name }).ToList(),
                 }).FirstOrDefault();

            return currentOrder;
        }

        public async Task UpdateOrderAsync(OrderViewModel input)
        {
            var currentOrder = this.dbOrder.All().Where(o => o.Id == input.OrderId).FirstOrDefault();

            if (currentOrder.Description != input.Description)
            {
                currentOrder.Description = this.sanitizer.Sanitize(input.Description);
            }

            if (currentOrder.Price != input.Price)
            {
                currentOrder.Price = input.Price;
            }

            if (currentOrder.Progress != input.Progress)
            {
                currentOrder.Progress = input.Progress;
            }

            this.dbOrder.Update(currentOrder);
            await this.dbOrder.SaveChangesAsync();
        }

        public async Task DeletedOrderAsync(string orderId)
        {
            var curentOrder = this.dbOrder.All().Where(o => o.Id == orderId).FirstOrDefault();

            var documentsToOrder = this.dbOrderDocument.All().Where(od => od.OrderId == curentOrder.Id).ToArray();

            foreach (var od in documentsToOrder)
            {
                await this.filesService.DeleteFileFromFileSystemAsync(od.DocumentId);
                this.dbOrderDocument.HardDelete(od);
            }

            this.dbOrder.HardDelete(curentOrder);

            await this.dbOrderDocument.SaveChangesAsync();
            await this.dbOrder.SaveChangesAsync();
        }

    }
}

namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Http;

    public class OrdersService : IOrdersService
    {
        private readonly IDeletableEntityRepository<OrderDocument> dbOrderDocument;
        private readonly IDeletableEntityRepository<Order> dbOrder;
        private readonly IFilesService filesService;

        public OrdersService(IDeletableEntityRepository<OrderDocument> dbOrderDocument, IDeletableEntityRepository<Order> dbOrder, IFilesService filesService)
        {
            this.dbOrderDocument = dbOrderDocument;
            this.dbOrder = dbOrder;
            this.filesService = filesService;
        }

        public async Task<string> AddDocumentToOrder(IFormFile document, string orderId, string userId)
        {
            var fileId = await this.filesService.UploadToFileSystem(document, "documents\\service", "Service Document");
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

        public async Task<string> AddOrder(OrderInputModel input)
        {
            var newOrder = new Order
            {
                ServiceId = input.ServiceId,
                Description = input.Description,
                UserId = input.UserId,
            };

            await this.dbOrder.AddAsync(newOrder);
            await this.dbOrder.SaveChangesAsync();

            foreach (var document in input.Documents)
            {
                await this.AddDocumentToOrder(document, newOrder.Id, input.UserId);
            }

            return newOrder.Id;
        }

        public ICollection<OrderViewModel> GetOrdersByUserId(string userId)
        {
            var allOrdersToUser = this.dbOrder.All()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new OrderViewModel
                {
                    OrderId = o.Id,
                    UserId = o.UserId,
                    Price = o.Price,
                    Description = o.Description,
                    CreatedOn = o.CreatedOn,
                    Progress = BgNameProgress(o.Progress),
                    ServiceId = o.ServiceId ?? default(int),
                    ServiceName = o.Service.Name,
                    Documents = o.Documents.Select(d => new DocumentViewModel { Id = d.Document.Id, Name = d.Document.Name }).ToList(),
                }).ToList();

            return allOrdersToUser;
        }

        public OrderViewModel GetOrderById(string orderId)
        {
            var currentOrder= this.dbOrder.All()
                 .Where(o => o.Id == orderId)
                 .Select(o => new OrderViewModel
                 {
                     OrderId = o.Id,
                     UserId = o.UserId,
                     Price = o.Price,
                     Description = o.Description,
                     CreatedOn = o.CreatedOn,
                     Progress = BgNameProgress(o.Progress),
                     ServiceId = o.ServiceId ?? default(int),
                     ServiceName = o.Service.Name,
                     Documents = o.Documents.Select(d => new DocumentViewModel { Id = d.Document.Id, Name = d.Document.Name }).ToList(),
                 }).FirstOrDefault();

            return currentOrder;
        }

        public async Task DeletedOrder(string orderId)
        {
            var curentOrder = this.dbOrder.All().Where(o => o.Id == orderId).FirstOrDefault();

            var documentsToOrder = this.dbOrderDocument.All().Where(od => od.OrderId == curentOrder.Id).ToArray();

            foreach (var od in documentsToOrder)
            {
                await this.filesService.DeleteFileFromFileSystem(od.DocumentId);
                this.dbOrderDocument.HardDelete(od);
            }

            this.dbOrder.HardDelete(curentOrder);

            await this.dbOrderDocument.SaveChangesAsync();
            await this.dbOrder.SaveChangesAsync();
        }

        private static string BgNameProgress(Progress progress)
        {
            if (progress == Progress.Wait)
            {
                return "Чакаща";
            }
            else if (progress == Progress.Accepted)
            {
                return "Приета";
            }
            else if (progress == Progress.Progress)
            {
                return "Обработва се";
            }
            else
            {
                return "Завършена";
            }
        }
    }
}

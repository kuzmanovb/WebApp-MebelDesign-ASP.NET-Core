namespace MebelDesign71.Services.Data
{
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
            };

            await this.dbOrder.AddAsync(newOrder);
            await this.dbOrder.SaveChangesAsync();

            var fileId = await this.filesService.UploadToFileSystem(input.Document, "documents\\service", "Service Document");
            var newUserDocument = new OrderDocument
            {
                UserId = input.UserId,
                DocumentId = fileId,
                OrderId = newOrder.Id,
            };

            await this.dbOrderDocument.AddAsync(newUserDocument);
            await this.dbOrderDocument.SaveChangesAsync();

            return newOrder.Id;
        }


    }
}

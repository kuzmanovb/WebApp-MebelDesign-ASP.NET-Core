namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Http;

    public interface IOrdersService
    {
        Task<string> AddOrderAsync(OrderInputModel input);

        Task<string> AddDocumentToOrderAsync(IFormFile document, string orderId, string userId, string number);

        ICollection<OrderViewModel> GetOrdersByUserId(string userId);

        ICollection<OrderViewModel> GetAllOrders();

        OrderViewModel GetOrderById(string orderId);

        Task DeletedOrderAsync(string orderId);

        Task UpdateOrderAsync(OrderViewModel input);

    }
}

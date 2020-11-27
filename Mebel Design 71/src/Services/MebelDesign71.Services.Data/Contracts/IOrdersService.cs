namespace MebelDesign71.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Http;

    public interface IOrdersService
    {
        Task<string> AddOrder(OrderInputModel input);

        Task<string> AddDocumentToOrder(IFormFile document, string orderId, string userId);

    }
}

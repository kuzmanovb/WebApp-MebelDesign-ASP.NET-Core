namespace MebelDesign71.Web.ViewModels.Orders
{
    using Microsoft.AspNetCore.Http;

    public class OrderInputModel
    {
        public string UserId { get; set; }

        public string Description { get; set; }

        public IFormFile Document { get; set; }

        public int ServiceId { get; set; }

    }
}

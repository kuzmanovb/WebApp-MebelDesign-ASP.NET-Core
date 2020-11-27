namespace MebelDesign71.Web.ViewModels.Orders
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class OrderInputModel
    {
        [Required]
        public string UserId { get; set; }

        public string Description { get; set; }

        public IFormFile Document { get; set; }

        public int ServiceId { get; set; }

    }
}

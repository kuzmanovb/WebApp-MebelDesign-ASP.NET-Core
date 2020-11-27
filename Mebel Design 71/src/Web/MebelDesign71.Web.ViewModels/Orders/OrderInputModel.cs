namespace MebelDesign71.Web.ViewModels.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class OrderInputModel
    {
        public OrderInputModel()
        {
            this.Documents = new List<IFormFile>();
        }

        [Required]
        public string UserId { get; set; }

        public string Description { get; set; }

        public ICollection<IFormFile> Documents { get; set; }

        public int ServiceId { get; set; }
    }
}

namespace MebelDesign71.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;

    using MebelDesign71.Data.Models;

    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string UserId { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Progress { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<DocumentViewModel> Documents { get; set; }
    }

}

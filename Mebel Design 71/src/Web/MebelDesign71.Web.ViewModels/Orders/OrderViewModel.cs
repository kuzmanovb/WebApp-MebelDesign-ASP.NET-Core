namespace MebelDesign71.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;

    using MebelDesign71.Data.Models;

    public class OrderViewModel
    {
        public string OrderId { get; set; }

        public string Number { get; set; }

        public string UserId { get; set; }

        public string UserEmail { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public Progress Progress { get; set; }

        public string ProgressDisplay { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string CreatedOn { get; set; }

        public ICollection<DocumentViewModel> Documents { get; set; }
    }

}

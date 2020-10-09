namespace MebelDesign71.Data.Models
{
    using System;

    using MebelDesign71.Data.Common.Models;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }


        public decimal Price { get; set; }

        public string Document { get; set; }

        public Status Status { get; set; }

        public int TypeServiceId { get; set; }
        public TypeService TypeService { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}

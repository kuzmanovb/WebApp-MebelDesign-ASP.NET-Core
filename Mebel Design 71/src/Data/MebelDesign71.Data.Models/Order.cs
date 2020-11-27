namespace MebelDesign71.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Documents = new HashSet<OrderDocument>();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public Progress Progress { get; set; } = Progress.Wait;

        public int? ServiceId { get; set; }

        public Service Service { get; set; }

        public ICollection<OrderDocument> Documents { get; set; }
    }
}

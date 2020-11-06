namespace MebelDesign71.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class Order : BaseDeletableModel<string>
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public decimal? Price { get; set; }

        public Progress Progress { get; set; }

        [Required]
        public string DocumentId { get; set; }

        public FileOnFileSystem Document { get; set; }

        [Required]
        public string ServiceId { get; set; }

        public Service Service { get; set; }
    }
}

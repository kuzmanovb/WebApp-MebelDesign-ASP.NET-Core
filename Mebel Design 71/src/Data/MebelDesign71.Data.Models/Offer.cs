namespace MebelDesign71.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MebelDesign71.Data.Common.Models;

    public class Offer : BaseDeletableModel<string>
    {
        public Offer()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Description { get; set; }

        public string Comment { get; set; }

        [ForeignKey("FileOnFileSystem")]
        public string DocumentId { get; set; }

        public FileOnFileSystem FileOnFileSystem { get; set; }
    }
}

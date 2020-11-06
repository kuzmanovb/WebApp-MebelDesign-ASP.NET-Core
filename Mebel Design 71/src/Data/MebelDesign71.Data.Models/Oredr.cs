using MebelDesign71.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MebelDesign71.Data.Models
{
    public class Oredr : BaseDeletableModel<string>
    {
        public Oredr()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

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

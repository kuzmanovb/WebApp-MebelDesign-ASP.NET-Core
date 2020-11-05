using MebelDesign71.Data.Common.Models;
using System;

namespace MebelDesign71.Data.Models
{
    public class Oredr : BaseDeletableModel<string>
    {
        public Oredr()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public decimal Price { get; set; }

        public Progress Progress { get; set; }

        public string ServiceId { get; set; }
        public Service Service { get; set; }
    }
}

using MebelDesign71.Data.Common.Models;
using System;

namespace MebelDesign71.Data.Models
{
    public class Review : BaseDeletableModel<string>
    {
        public Review()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }

    }
}

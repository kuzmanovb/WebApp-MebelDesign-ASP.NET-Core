using System;

namespace MebelDesign71.Data.Models
{
    public class Image
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string ImageTitle { get; set; }

        public string ImageUrl { get; set; }
    }
}
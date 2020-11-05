using MebelDesign71.Data.Common.Models;

namespace MebelDesign71.Data.Models
{
    public class Service 
    {
        public int Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public string Description { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }

    }
}
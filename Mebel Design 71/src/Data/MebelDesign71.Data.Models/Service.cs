namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Service
    {
        public int Id { get; set; }

        public ServiceType ServiceType { get; set; }

        [Required]
        public string Description { get; set; }

        public int ImageId { get; set; }

        public ImageToProject Image { get; set; }

    }
}
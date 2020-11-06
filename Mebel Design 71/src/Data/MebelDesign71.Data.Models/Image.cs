namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImageTitle { get; set; }

        public FileOnFileSystem ImagePath { get; set; }
    }
}
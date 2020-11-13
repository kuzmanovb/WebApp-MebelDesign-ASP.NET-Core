namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ImageToReview
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string FileId { get; set; }

            public FileOnFileSystem File { get; set; }
    }

}

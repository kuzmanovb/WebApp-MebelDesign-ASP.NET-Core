namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class ImageToReview : BaseModel<int>
    {

            [Required]
            public string FileId { get; set; }

            public FileOnFileSystem File { get; set; }
    }

}

namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class GalleryProject : BaseModel<int>
    {

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public string FileId { get; set; }

        public FileOnFileSystem File { get; set; }
    }
}
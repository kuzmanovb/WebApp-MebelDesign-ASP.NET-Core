namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MebelDesign71.Data.Common.Models;

    public class ImageToProject : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        [Required]
        public string FileId { get; set; }

        public FileOnFileSystem File { get; set; }
    }
}
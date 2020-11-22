namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string HeadImageId { get; set; }

        public FileOnFileSystem HeadImage { get; set; }

        public string UploadDocumentId { get; set; }

        public FileOnFileSystem UploadDocument { get; set; }

        public string DownloadDocumentId { get; set; }

        public FileOnFileSystem DownloadDocument { get; set; }
    }
}

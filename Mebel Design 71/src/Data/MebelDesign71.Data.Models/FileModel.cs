using MebelDesign71.Data.Common.Models;
using System;

namespace MebelDesign71.Data.Models
{
    public abstract class FileModel
    {
        public FileModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string FileType { get; set; }

        public string Extension { get; set; }

        public string Description { get; set; }

        public string UploadedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

    }
}

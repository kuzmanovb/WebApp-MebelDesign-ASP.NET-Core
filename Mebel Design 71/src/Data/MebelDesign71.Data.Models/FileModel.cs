namespace MebelDesign71.Data.Models
{
    using System;

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

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}

namespace MebelDesign71.Data.Models
{
    using System;

    using MebelDesign71.Data.Common.Models;

    public class UserDocument : BaseDeletableModel<string>
    {
        public UserDocument()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DocumentId { get; set; }

        public FileOnFileSystem Document { get; set; }

    }
}

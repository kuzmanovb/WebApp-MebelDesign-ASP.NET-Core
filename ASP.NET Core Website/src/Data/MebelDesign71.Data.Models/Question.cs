namespace MebelDesign71.Data.Models
{
    using System;

    using MebelDesign71.Data.Common.Models;

    public class Question : BaseDeletableModel<string>
    {

        public Question()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}

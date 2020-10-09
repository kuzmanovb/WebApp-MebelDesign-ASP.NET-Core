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

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}

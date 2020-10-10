namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}

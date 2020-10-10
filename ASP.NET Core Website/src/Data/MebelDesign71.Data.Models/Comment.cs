namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}

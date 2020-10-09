namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;

    public class TypeService : BaseDeletableModel<int>
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }
    }
}

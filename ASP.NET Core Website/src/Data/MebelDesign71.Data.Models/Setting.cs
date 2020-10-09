namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}

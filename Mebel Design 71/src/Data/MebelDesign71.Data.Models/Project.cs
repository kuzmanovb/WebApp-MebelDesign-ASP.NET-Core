namespace MebelDesign71.Data.Models
{
    using MebelDesign71.Data.Common.Models;

    public class Project : BaseModel<int>
    {
        public ProjectType ProjectType { get; set; }

        public int ImageId { get; set; }

        public ImageToProject Image { get; set; }
    }
}

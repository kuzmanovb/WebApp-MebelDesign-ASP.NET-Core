using MebelDesign71.Data.Common.Models;

namespace MebelDesign71.Data.Models
{
    public class Project : BaseModel<int>
    {
        public ProjectType ProjectType { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }
    }
}

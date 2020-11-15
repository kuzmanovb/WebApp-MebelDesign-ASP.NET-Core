namespace MebelDesign71.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using MebelDesign71.Data.Common.Models;

    public class Project : BaseModel<int>
    {

        public string Name { get; set; }

        [ForeignKey("ImageToProject")]
        public int HeadImageId{ get; set; }

        public ImageToProject Image { get; set; }

    }
}

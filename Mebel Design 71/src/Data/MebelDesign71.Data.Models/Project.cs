namespace MebelDesign71.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MebelDesign71.Data.Common.Models;

    public class Project : BaseModel<int>
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string HeadImageId{ get; set; }

        public FileOnFileSystem HeadImage { get; set; }


    }
}

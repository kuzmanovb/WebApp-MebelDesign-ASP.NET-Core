using System.ComponentModel.DataAnnotations;

namespace MebelDesign71.Web.ViewModels.Projects
{
    public class ProjectViewModel
    {
        public int Id { get; set; }


        [Display(Name ="Име")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Снимка")]
        public string HeadImage { get; set; }

        public string IsDeleted { get; set; }
    }
}

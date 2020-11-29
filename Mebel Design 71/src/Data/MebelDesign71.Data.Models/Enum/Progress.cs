namespace MebelDesign71.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum Progress
    {
        [Display(Name = "Чакаща")]
        [Description("Чакаща")]
        Wait = 1,

        [Display(Name = "Приета")]
        [Description("Приета")]
        Accepted = 2,

        [Display(Name = "Обработва се")]
        [Description("Обработва се")]
        Progress = 3,

        [Display(Name = "Завършена")]
        [Description("Завършена")]
        Finish = 4,
    }
}

namespace MebelDesign71.Web.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MebelDesign71.Data.Models;

    public class OrderViewModel
    {
        public string OrderId { get; set; }

        [Display(Name = "Номер на поръчката")]
        public string Number { get; set; }

        public string UserId { get; set; }

        [Display(Name ="Имейл")]
        public string UserEmail { get; set; }

        [Display(Name = "Цена")]
        public decimal? Price { get; set; }

        [Display(Name = "Забележка към поръчката")]
        public string Description { get; set; }

        [Display(Name = "Статус")]
        public Progress Progress { get; set; }

        public string ProgressDisplay { get; set; }

        public int ServiceId { get; set; }

        [Display(Name = "Вид услуга")]
        public string ServiceName { get; set; }

        [Display(Name = "Дата")]
        public string CreatedOn { get; set; }

        [Display(Name = "Прикачени документи")]
        public ICollection<DocumentViewModel> Documents { get; set; }
    }

}

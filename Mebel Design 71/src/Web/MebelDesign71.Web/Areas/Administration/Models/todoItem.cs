using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MebelDesign71.Web.Areas.Administration.Models
{
    public class todoItem
    {
        public todoItem()
        {
            progress = 0;
        }
        public int id { get; set; }
        [Required]
        [StringLength(100)]
        public string todo { get; set; }
        [Range(0, 100, ErrorMessage = "Enter a value between 1 and 100")]
        public int progress { get; set; }
    }
}

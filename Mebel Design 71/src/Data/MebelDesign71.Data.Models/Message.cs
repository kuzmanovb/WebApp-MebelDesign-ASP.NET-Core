namespace MebelDesign71.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using MebelDesign71.Data.Common.Models;

    public class Message : BaseDeletableModel<string>
    {

        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public string Description { get; set; }
    }
}

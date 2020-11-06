using System;

using MebelDesign71.Data.Common.Models;

namespace MebelDesign71.Data.Models
{
    public class Message : BaseModel<string>
    {

        public Message()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }
    }
}

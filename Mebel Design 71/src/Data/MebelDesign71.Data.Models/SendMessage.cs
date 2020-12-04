namespace MebelDesign71.Data.Models
{
    using System;

    using MebelDesign71.Data.Common.Models;

    public class SendMessage : BaseDeletableModel<string>
    {
        public SendMessage()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ToEmail { get; set; }

        public string ToMessageId { get; set; }

        public Message ToMessage { get; set; }

        public string About { get; set; }

        public string Description { get; set; }
    }
}

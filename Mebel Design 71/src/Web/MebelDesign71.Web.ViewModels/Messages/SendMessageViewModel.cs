namespace MebelDesign71.Web.ViewModels.Messages
{
    public class SendMessageViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string ToMessageId { get; set; }

        public string About { get; set; }

        public string Description { get; set; }

        public string CreateOn { get; set; }

        public string TimeAgo { get; set; }

        public string ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}

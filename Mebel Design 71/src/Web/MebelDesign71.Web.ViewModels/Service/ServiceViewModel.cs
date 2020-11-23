namespace MebelDesign71.Web.ViewModels.Service
{
    using System.Collections.Generic;

    public class ServiceViewModel
    {
        public string Name { get; set; }

        public ICollection<string> Description { get; set; }

        public string HeadImageId { get; set; }

        public string DocumentId { get; set; }
    }
}

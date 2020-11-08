namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : Controller
    {

        public IActionResult ContactIndex()
        {
            return this.View();

        }

        [HttpPost]
        public IActionResult ContactIndex(ContactFormViewModel input)
        {
            return this.View();

        }

    }
}

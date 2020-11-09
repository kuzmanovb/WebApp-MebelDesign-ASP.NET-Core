namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data;
    using MebelDesign71.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ContactsController : BaseController
    {
        private readonly IContactsService contactsService;

        public ContactsController(IContactsService contactsService)
        {
            this.contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return this.View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var messageId = await this.contactsService.AddMessageAsync(input);

            this.TempData["Email"] = input.Email;
            this.TempData["About"] = input.About;

            //ToDo: SendEmai

            return this.RedirectToAction("ThankYou");


        }

        public IActionResult ThankYou()
        {

            return this.View();

        }

    }
}

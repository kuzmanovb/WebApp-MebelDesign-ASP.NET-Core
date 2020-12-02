namespace MebelDesign71.Web.Controllers
{
    using System.Threading.Tasks;

    using MebelDesign71.Services.Data;
    using MebelDesign71.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : BaseController
    {
        private readonly IMessagesService contactsService;

        public MessagesController(IMessagesService contactsService)
        {
            this.contactsService = contactsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var messageId = await this.contactsService.AddMessageAsync(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }

    }
}

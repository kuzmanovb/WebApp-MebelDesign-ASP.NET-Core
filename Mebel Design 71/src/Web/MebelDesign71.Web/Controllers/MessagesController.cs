namespace MebelDesign71.Web.Controllers
{
    using System.Threading.Tasks;
    using GoogleReCaptcha.V3.Interface;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Mvc;

    public class MessagesController : BaseController
    {
        private readonly IMessagesService contactsService;
        private readonly ICaptchaValidator captchaValidator;

        public MessagesController(IMessagesService contactsService, ICaptchaValidator captchaValidator)
        {
            this.contactsService = contactsService;
            this.captchaValidator = captchaValidator;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(MessageInputModel input, string captcha)
        {
            if (!await this.captchaValidator.IsCaptchaPassedAsync(captcha))
            {
                this.ModelState.AddModelError("captcha", "Captcha validation failed");
            }

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

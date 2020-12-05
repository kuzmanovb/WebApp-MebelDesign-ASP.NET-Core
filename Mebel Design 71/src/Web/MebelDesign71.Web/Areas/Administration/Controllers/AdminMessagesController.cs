namespace MebelDesign71.Web.Areas.Administration.Controllers
{

    using System.Threading.Tasks;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Messages;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AdminMessagesController : AdministrationController
    {
        private readonly IMessagesService messagesService;

        public AdminMessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }

        public IActionResult Index()
        {
            var allMessages = this.messagesService.GetAllMessages();
            var deletedMessage = this.messagesService.GetIsDeletedMessages();
            this.ViewData["allMessages"] = allMessages;

            return this.View();
        }

        public IActionResult Write(string id, string email, string about)
        {
            this.ViewData["toMessageId"] = id;
            this.ViewData["email"] = email;
            this.ViewData["about"] = about;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Write(SendMessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            //await this.emailSender.SendEmailAsync(InfoConstant.SecondEmail, GlobalConstants.SystemName, input.Email, input.About, input.Description);

            await this.messagesService.AddSendMessageAsync(input);

            return this.RedirectToAction("Send");
        }

        public IActionResult Read(string id)
        {
            var currentMessage = this.messagesService.GetMessageById(id);

            return this.View(currentMessage);
        }

        public IActionResult ReadSendMessage(string id)
        {
            var currentMessage = this.messagesService.GetSendMessagesById(id);

            return this.View(currentMessage);
        }

        public IActionResult Sent()
        {
            var allSendMessages = this.messagesService.GetAllSendMessages();
            this.ViewData["allSendMessages"] = allSendMessages;

            return this.View();
        }

        public IActionResult Trash()
        {
            var allDeletedMessages = this.messagesService.GetIsDeletedMessages();
            this.ViewData["allDeletedMessages"] = allDeletedMessages;

            return this.View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.messagesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSendMessage(string id)
        {
            await this.messagesService.DeleteSendMessageAsync(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Undelete(string id)
        {
            await this.messagesService.RestoreAsync(id);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> HardDelete(string id)
        {
            await this.messagesService.HardDeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}

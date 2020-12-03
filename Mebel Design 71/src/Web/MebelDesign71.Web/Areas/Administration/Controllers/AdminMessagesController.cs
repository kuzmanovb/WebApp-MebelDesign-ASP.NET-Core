namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

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
            this.ViewData["messagesCount"] = allMessages.Count;
            this.ViewData["deletedMessagesCount"] = deletedMessage.Count;

            return this.View();
        }

        public IActionResult Compose()
        {
            return this.View();
        }

        public IActionResult ReadMail()
        {
            return this.View();
        }
    }
}
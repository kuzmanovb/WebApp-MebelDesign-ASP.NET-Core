namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminMessagesController : AdministrationController
    {
        public IActionResult Index()
        {
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
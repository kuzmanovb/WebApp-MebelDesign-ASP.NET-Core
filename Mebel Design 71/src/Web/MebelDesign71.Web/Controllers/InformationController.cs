using Microsoft.AspNetCore.Mvc;

namespace MebelDesign71.Web.Controllers
{
    public class InformationController : BaseController
    {

        public IActionResult AboutUs()
        {

            return this.View();

        }

        public IActionResult Contacts()
        {
            return this.View();
        }

    }
}

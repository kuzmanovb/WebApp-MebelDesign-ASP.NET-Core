namespace MebelDesign71.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class InformationController : BaseController
    {

        public IActionResult AboutUs()
        {

            return this.View();

        }

        public IActionResult Reviews()
        {

            return this.View();

        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MebelDesign71.Web.Controllers
{
    public class ServicesController : BaseController
    {

        public IActionResult Index()
        {

            return this.View();

        }
    }
}

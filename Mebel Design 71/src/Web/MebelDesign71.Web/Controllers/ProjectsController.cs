using Microsoft.AspNetCore.Mvc;

namespace MebelDesign71.Web.Controllers
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult CurrentProject(string category)
        {
            return this.View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MebelDesign71.Web.Controllers
{
    public class ProjectsController : BaseController
    {
        [HttpGet]
        public IActionResult ProjectIndex()
        {
            return this.View();
        }

        public IActionResult CurrentProject(string category)
        {
            return this.View();
        }
    }
}

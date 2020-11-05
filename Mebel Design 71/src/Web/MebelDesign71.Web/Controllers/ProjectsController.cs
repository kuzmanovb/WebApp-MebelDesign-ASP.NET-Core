using Microsoft.AspNetCore.Mvc;

namespace MebelDesign71.Web.Controllers
{
    public class ProjectsController : BaseController
    {

        public IActionResult ProjectIndex()
        {
            return this.View();
        }

        public IActionResult CurrentProject()
        {

            return this.View();
        }

    }
}

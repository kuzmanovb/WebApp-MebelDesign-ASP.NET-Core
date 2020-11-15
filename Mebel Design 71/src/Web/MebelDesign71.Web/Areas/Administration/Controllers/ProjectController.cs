namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Data;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProjectController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            return View();
        }
    }
}
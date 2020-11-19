namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using MebelDesign71.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class AdminProjectGalleriesController : BaseController
    {
        public AdminProjectGalleriesController()
        {
                
        }
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Gallery()
        {
            return this.View();
        }
    }
}

namespace MebelDesign71.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdminServicesController : AdministrationController
    {

        public IActionResult Index()
        {
            //var allProjects = this.projectsService.GetAllProjectsWithDeleted();

            //this.ViewData["AllProjects"] = allProjects;

            return this.View();
        }
    }
}

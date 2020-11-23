namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class ServicesController : BaseController
    {
        private readonly IServicesService servicesService;

        public ServicesController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public IActionResult Index()
        {

            this.ViewData["services"] = this.servicesService.GetAllService();

            return this.View();

        }
    }
}

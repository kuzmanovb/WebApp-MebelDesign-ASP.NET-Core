namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IServicesService servicesService;

        public OrdersController(IServicesService servicesService)
        {
            this.servicesService = servicesService;
        }

        public IActionResult Index()
        {
            return this.View();

        }

        public IActionResult OrderForm()
        {
            this.ViewData["services"] = this.servicesService.GetAllService();
            return this.View();
        }

        [HttpPost]
        public IActionResult OrderForm(OrderInputModel input)
        {

            if (!this.ModelState.IsValid)
            {
                this.ViewData["services"] = this.servicesService.GetAllService();
                return this.View(input);
            }



            return this.RedirectToAction("Index");
        }
    }
}

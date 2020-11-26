namespace MebelDesign71.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class OrdersController : BaseController
    {

        public IActionResult Index()
        {
            return this.View();

        }

        public IActionResult OrderForm()
        {
            return this.View();

        }
    }
}

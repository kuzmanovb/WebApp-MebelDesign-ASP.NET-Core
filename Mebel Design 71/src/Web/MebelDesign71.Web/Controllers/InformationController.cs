namespace MebelDesign71.Web.Controllers
{
    using MebelDesign71.Services.Data;
    using MebelDesign71.Web.ViewModels.Information;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class InformationController : BaseController
    {
        private readonly IInformationService informationService;

        public InformationController(IInformationService informationService)
        {
            this.informationService = informationService;
        }

        public IActionResult AboutUs()
        {

            return this.View();

        }

        public async Task<IActionResult> Reviews()
        {
            var allReview = await this.informationService.GetAllReview();

            this.ViewData["Reviews"] = allReview;

            return this.View();
        }

        // ToDo: Only registered users
        public IActionResult AddReview()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.informationService.AddRewiev(input);

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}

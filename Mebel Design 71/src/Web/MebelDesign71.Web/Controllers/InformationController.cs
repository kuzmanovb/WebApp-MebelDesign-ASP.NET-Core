namespace MebelDesign71.Web.Controllers
{
    using System.Threading.Tasks;

    using MebelDesign71.Common;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Information;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

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


        [Authorize]
        public IActionResult AddReview()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddReview(ReviewInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.informationService.AddRewiev(input);

            return this.RedirectToAction("ThankYou");
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> DeleteReview(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Reviews");
            }

            await this.informationService.DeleteReview(id);

            return this.RedirectToAction("Reviews");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}

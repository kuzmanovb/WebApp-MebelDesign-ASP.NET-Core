namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Information;

    public interface IInformationService
    {

        Task<string> AddRewiev(ReviewInputModel input);

        Task<ICollection<ReviewViewModel>> GetAllReview();
    }
}

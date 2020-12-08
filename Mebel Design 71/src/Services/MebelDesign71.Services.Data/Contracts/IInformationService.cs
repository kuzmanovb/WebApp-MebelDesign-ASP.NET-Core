namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Information;

    public interface IInformationService
    {

        Task<string> AddRewievAsync(ReviewInputModel input);

        Task<ICollection<ReviewViewModel>> GetAllReviewAsync();

        Task DeleteReviewAsync(string id);
    }
}

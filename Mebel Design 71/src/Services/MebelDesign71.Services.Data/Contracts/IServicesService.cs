namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Service;

    public interface IServicesService
    {
        IEnumerable<ServiceInputModel> GetAllService();

        IEnumerable<ServiceInputModel> GetAllServiceWithDeleted();

        Task<ServiceViewModel> GetServiceByIdForViewAsync(int id);

        Task<ServiceInputModel> GetServiceByIdAsync(int id);

        Task<int> CreateServiceAsync(ServiceInputModel input);

        Task UpdateServiceAsync(ServiceInputModel input);

        Task ChangeIsDeleteServiceAsync(int id);

        Task DeleteAsync(int id);
    }
}

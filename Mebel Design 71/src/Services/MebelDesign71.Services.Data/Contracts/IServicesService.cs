namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Service;

    public interface IServicesService
    {
        IEnumerable<ServiceInputModel> GetAllService();

        IEnumerable<ServiceInputModel> GetAllServiceWithDeleted();

        Task<ServiceViewModel> GetServiceByIdForView(int id);

        Task<ServiceInputModel> GetServiceById(int id);

        Task<int> CreateService(ServiceInputModel input);

        Task UpdateService(ServiceInputModel input);

        Task ChangeIsDeleteService(int id);
    }
}

namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Service;

    public interface IServicesService
    {
        IEnumerable<ServiceViewModel> GetAllService();

        IEnumerable<ServiceViewModel> GetAllServiceWithDeleted();

        Task<ServiceInputModel> GetServiceById(int id);

        Task<int> Createservice(ServiceInputModel input);

        Task UpdateService(ServiceInputModel input);

        Task ChangeIsDeleteService(int id);
    }
}

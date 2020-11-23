namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Service;

    public class ServicesService : IServicesService
    {
        public IEnumerable<ServiceViewModel> GetAllService()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ServiceViewModel> GetAllServiceWithDeleted()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceInputModel> GetServiceById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Createservice(ServiceInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateService(ServiceInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public Task ChangeIsDeleteService(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

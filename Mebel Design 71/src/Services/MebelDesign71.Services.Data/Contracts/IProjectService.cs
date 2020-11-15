namespace MebelDesign71.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Projects;

    public interface IProjectService
    {

        public Task<ProjectViewModel> GetAllProject();

        public Task<int> CreateProject(ProjectInputModel input);

        public Task<bool> DeleteProject(int id);

        public Task<bool> UpdateProject(int id);
    }
}

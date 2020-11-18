namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        IEnumerable<ProjectViewModel> GetAllProjectsWithDeleted();

        Task<ProjectInputModel> GetProjectById(int id);

        Task<int> CreateProject(ProjectInputModel input);

        Task UpdateProject(ProjectInputModel input);

        Task ChangeIsDeleteProject(int id);
    }
}

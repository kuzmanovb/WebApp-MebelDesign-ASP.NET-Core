namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Projects;

    public interface IProjectsService
    {
        IEnumerable<ProjectViewModel> GetAllProjects();

        IEnumerable<ProjectViewModel> GetAllProjectsWithDeleted();

        Task<ProjectInputModel> GetProjectByIdAsync(int id);

        Task<int> CreateProjectAsync(ProjectInputModel input);

        Task UpdateProjectAsync(ProjectInputModel input);

        Task ChangeIsDeleteProjectAsync(int id);

        Task DeleteProjectAsync(int id);
    }
}

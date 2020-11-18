using MebelDesign71.Data.Common.Repositories;
using MebelDesign71.Data.Models;
using MebelDesign71.Web.ViewModels.Projects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MebelDesign71.Services.Data.Contracts
{
    public interface IProjectService
    {

        IEnumerable<ProjectViewModel> GetAllProjects();

        Task<ProjectViewModel> GetProjectById(int id);

        Task<int> CreateProject(ProjectInputModel input);

        Task UpdateProject(ProjectInputModel input);

        Task ChangeIsDeleteProject(int id);
    }
}

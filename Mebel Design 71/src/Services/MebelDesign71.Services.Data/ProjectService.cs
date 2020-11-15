namespace MebelDesign71.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Projects;

    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> dbProject;

        public ProjectService(IDeletableEntityRepository<Project> dbProject)
        {
            this.dbProject = dbProject;
        }
        public Task<int> CreateProject(ProjectInputModel input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectViewModel> GetAllProject()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProject(int id)
        {
            throw new NotImplementedException();
        }
    }
}

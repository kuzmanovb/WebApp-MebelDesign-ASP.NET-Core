namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Orders;
    using MebelDesign71.Web.ViewModels.Projects;
    using MebelDesign71.Web.ViewModels.ProjectsImage;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;
    public class ProjectsServiceTest : IDisposable
    {
        private readonly IFilesService filesService;
        private readonly IProjectsService projectsService;

        private EfDeletableEntityRepository<Project> progectRepository;
        private EfRepository<FileOnFileSystem> filesRepository;

        private ApplicationDbContext connection;

        private HostingEnvironment environment;

        private IFormFile file;


        public ProjectsServiceTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.progectRepository = new EfDeletableEntityRepository<Project>(this.connection);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);

            this.environment = new HostingEnvironment();

            this.filesService = new FilesService(this.filesRepository, this.environment);
            this.projectsService = new ProjectsService(this.progectRepository, this.filesService);

            this.InitializeFields();
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task TestCreateProject()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var projectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            Assert.True(projectId > 0);
        }

        [Fact]
        public async Task TestGetAllProjects()
        {

            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            await this.projectsService.CreateProjectAsync(projectInputModel);
            await this.projectsService.CreateProjectAsync(projectInputModel);

            var projects = this.projectsService.GetAllProjects().ToList();

            Assert.NotNull(projects);
        }

        [Fact]
        public async Task TestGetAllProjectsWithDeletedAndChangeIsDeleteProject()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var progectId = await this.projectsService.CreateProjectAsync(projectInputModel);
            await this.projectsService.CreateProjectAsync(projectInputModel);

            await this.projectsService.ChangeIsDeleteProjectAsync(progectId);

            var projects = this.projectsService.GetAllProjectsWithDeleted().ToList();

            Assert.NotNull(projects);
        }

        [Fact]
        public async Task TestGetProjectByIdAsync()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var progectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var projects = this.projectsService.GetProjectByIdAsync(progectId);

            Assert.Equal(progectId, projects.Id);
        }

        [Fact]
        public async Task TestUpdateProjectAsync()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var progectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var projectInputModelForChange = new ProjectInputModel
            {
                Id = progectId,
                Name = "change test",
                Description = "Change Lorem",
                HeadImage = null,
            };

            await this.projectsService.UpdateProjectAsync(projectInputModelForChange);

            var projects = await this.projectsService.GetProjectByIdAsync(progectId);

            Assert.NotEqual("test", projects.Name);
            Assert.Equal("Change Lorem", projects.Description);
        }

        [Fact]
        public async Task TestDeleteProject()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var progectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var projects = await this.projectsService.GetProjectByIdAsync(progectId);

            //Assert.Null
            
        }

        private void InitializeFields()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.jpg";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            this.file = fileMock.Object;
        }


    }
}

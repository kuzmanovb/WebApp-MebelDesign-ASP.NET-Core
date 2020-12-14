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

    public class ProjectsGalleryTest
    {
        private readonly IFilesService filesService;
        private readonly IProjectsService projectsService;
        private readonly IProjectsGalleryService projectsGalleryService;

        private EfDeletableEntityRepository<Project> progectRepository;
        private EfRepository<GalleryProject> galleryProgectRepository;
        private EfRepository<FileOnFileSystem> filesRepository;

        private ApplicationDbContext connection;

        private HostingEnvironment environment;

        private IFormFile file;

        public ProjectsGalleryTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.galleryProgectRepository = new EfRepository<GalleryProject>(this.connection);
            this.progectRepository = new EfDeletableEntityRepository<Project>(this.connection);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);

            this.environment = new HostingEnvironment();

            this.filesService = new FilesService(this.filesRepository, this.environment);
            this.projectsService = new ProjectsService(this.progectRepository, this.filesService);
            this.projectsGalleryService = new ProjectsGalleryService(this.galleryProgectRepository, this.filesRepository, this.filesService, this.projectsService);

            this.InitializeFields();
        }

        [Fact]
        public async Task TestAddImageToGallery()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var projectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var imageInputModel = new ImageInputModel
            {
                ProjectId = projectId,
                Description = "Lorem",
                ImageFile = this.file,
            };

            var id = await this.projectsGalleryService.AddImageToGalleryAsync(imageInputModel);

            Assert.NotEqual(0, id);
        }

        [Fact]
        public async Task TestGetGallery()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var projectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var imageInputModel = new ImageInputModel
            {
                ProjectId = projectId,
                Description = "Lorem",
                ImageFile = this.file,
            };

            var id = await this.projectsGalleryService.AddImageToGalleryAsync(imageInputModel);

            var currentGallery = await this.projectsGalleryService.GetGalleryAsync(projectId);

            Assert.NotNull(currentGallery);
        }

        [Fact]
        public async Task TestDeleteImageAsync()
        {
            var projectInputModel = new ProjectInputModel
            {
                Name = "test",
                Description = "Lorem",
                HeadImage = this.file,
            };

            var projectId = await this.projectsService.CreateProjectAsync(projectInputModel);

            var imageInputModel = new ImageInputModel
            {
                ProjectId = projectId,
                Description = "Lorem",
                ImageFile = this.file,
            };

            var id = await this.projectsGalleryService.AddImageToGalleryAsync(imageInputModel);

            await this.projectsGalleryService.DeleteImageAsync(id);

            var currentGallery = await this.projectsGalleryService.GetGalleryAsync(projectId);

            Assert.Equal(0, currentGallery.Count);
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

namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Service;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class ServicesServiceTest : IDisposable
    {
        private readonly IFilesService filesService;
        private readonly IServicesService servicesService;

        private EfDeletableEntityRepository<Service> serviceRepository;
        private EfRepository<FileOnFileSystem> filesRepository;

        private HostingEnvironment environment;

        private ApplicationDbContext connection;

        private IFormFile file;
        private IFormFile document;

        public ServicesServiceTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
             .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.serviceRepository = new EfDeletableEntityRepository<Service>(this.connection);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);

            this.environment = new HostingEnvironment();

            this.filesService = new FilesService(this.filesRepository, this.environment);
            this.servicesService = new ServicesService(this.serviceRepository, this.filesService);

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
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            Assert.True(id > 0);
        }

        [Fact]
        public async Task TestGetAllService()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var idOne = await this.servicesService.CreateServiceAsync(newServiceInputModel);
            var idTwo = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            var allServices = this.servicesService.GetAllService().ToList();
        }

        [Fact]
        public async Task TestGetAllServiceWithDeleted()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var idOne = await this.servicesService.CreateServiceAsync(newServiceInputModel);
            var idTwo = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            await this.servicesService.ChangeIsDeleteServiceAsync(idOne);

            var services = this.serviceRepository.AllWithDeleted();

            Assert.Equal(2, services.ToList().Count);
        }

        [Fact]
        public async Task TestGetServiceById()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            var service = await this.servicesService.GetServiceByIdAsync(id);

            Assert.Equal(id, service.Id);
        }

        [Fact]
        public async Task TestGetServiceByIdForView()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            var service = await this.servicesService.GetServiceByIdForViewAsync(id);

            Assert.NotNull(service);
        }

        [Fact]
        public async Task TestUpdateService()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            var newServiceInputModelForUpdate = new ServiceInputModel
            {
                Id = id,
                Name = "test update",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Update",
                HeadImage = this.file,
                Document = this.document,
            };

            await this.servicesService.UpdateServiceAsync(newServiceInputModelForUpdate);

            var service = await this.servicesService.GetServiceByIdForViewAsync(id);

            Assert.Equal("test update", service.Name);
        }

        [Fact]
        public async Task TestChangeIsDeleteService()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            await this.servicesService.ChangeIsDeleteServiceAsync(id);

            var service = this.serviceRepository.AllWithDeleted().FirstOrDefault();

            Assert.True(service.IsDeleted);
        }

        [Fact]
        public async Task TestDelete()
        {
            var newServiceInputModel = new ServiceInputModel
            {
                Name = "test",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
                HeadImage = this.file,
                Document = this.document,
            };

            var id = await this.servicesService.CreateServiceAsync(newServiceInputModel);

            await this.servicesService.DeleteAsync(id);

            var service = await this.servicesService.GetServiceByIdAsync(id);

            Assert.Null(service);
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

            var documentMock = new Mock<IFormFile>();
            var contentDoc = "Hello World from a Fake File";
            var fileNameDoc = "test.jpg";
            var msDoc = new MemoryStream();
            var writerDoc = new StreamWriter(ms);
            writerDoc.Write(contentDoc);
            writerDoc.Flush();
            msDoc.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(msDoc);
            fileMock.Setup(_ => _.FileName).Returns(fileNameDoc);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            this.document = documentMock.Object;
        }

    }
}

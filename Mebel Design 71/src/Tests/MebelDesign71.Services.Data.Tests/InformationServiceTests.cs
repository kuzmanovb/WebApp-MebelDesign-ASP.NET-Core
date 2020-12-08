namespace MebelDesign71.Services.Data.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Information;

    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class InformationServiceTests : IDisposable
    {
        private readonly IInformationService informationService;
        private readonly IFilesService filesService;

        private ApplicationDbContext connection;

        private EfRepository<ImageToReview> imageRepository;
        private EfDeletableEntityRepository<Review> reviewRepository;
        private EfRepository<FileOnFileSystem> filesRepository;

        private HostingEnvironment environment;

        private IFormFile imageFileDefault;
        private IFormFile imageFile;

        public InformationServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            this.connection = new ApplicationDbContext(options);

            this.imageRepository = new EfRepository<ImageToReview>(this.connection);
            this.reviewRepository = new EfDeletableEntityRepository<Review>(this.connection);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);

            this.environment = new HostingEnvironment();

            this.filesService = new FilesService(this.filesRepository, this.environment);
            this.informationService = new InformationService(this.imageRepository, this.reviewRepository, this.filesService);

            this.InitializeTestFile();
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task TestAddingReiewWithImageFile()
        {
            var fileId = await this.filesService.UploadToFileSystem(this.imageFileDefault, "test");
            await this.imageRepository.AddAsync(new ImageToReview { FileId = fileId });
            await this.imageRepository.SaveChangesAsync();

            var model = new ReviewInputModel
            {
                Name = "Test",
                Description = "Lorem Ipsum is simply dummy text.",
                ImageFile = this.imageFile,
            };

            await this.informationService.AddRewievAsync(model);

            var currentModel = await this.reviewRepository.All().FirstOrDefaultAsync();

            Assert.Equal("Test", currentModel.Name);
            Assert.Equal("Lorem Ipsum is simply dummy text.", currentModel.Description);
        }

        [Fact]
        public async Task TestAddingReiewWithoutImage()
        {
            var fileId = await this.filesService.UploadToFileSystem(this.imageFileDefault, "test");
            await this.imageRepository.AddAsync(new ImageToReview { FileId = fileId });
            await this.imageRepository.SaveChangesAsync();

            var model = new ReviewInputModel
            {
                Name = "Test",
                Description = "Lorem Ipsum is simply dummy text.",
            };

            await this.informationService.AddRewievAsync(model);

            var currentModel = await this.reviewRepository.All().FirstOrDefaultAsync();

            Assert.Equal("Test", currentModel.Name);
            Assert.Equal("Lorem Ipsum is simply dummy text.", currentModel.Description);
        }

        [Fact]
        public void TestGetAllReview()
        {
            var countReview = this.informationService.GetAllReviewAsync().Result.Count;

            Assert.Equal(0, countReview);
        }

        [Fact]
        public async Task TestDeleteRewiev()
        {
            var fileId = await this.filesService.UploadToFileSystem(this.imageFileDefault, "test");
            await this.imageRepository.AddAsync(new ImageToReview { FileId = fileId });
            await this.imageRepository.SaveChangesAsync();

            var model = new ReviewInputModel
            {
                Name = "Test",
                Description = "Lorem Ipsum is simply dummy text.",
                ImageFile = this.imageFile,
            };

            await this.informationService.AddRewievAsync(model);

            var currentModel = await this.reviewRepository.All().FirstOrDefaultAsync();

            await this.informationService.DeleteReviewAsync(currentModel.Id);

            var countReview = this.informationService.GetAllReviewAsync().Result.Count;

            Assert.Equal(0, countReview);
        }







        // End Testing ---------------------------------------------------------------------------------------------------------------
        private void InitializeTestFile()
        {
            var imageFileDefaultMock = new Mock<IFormFile>();
            var defaultContent = "Hello World from a Fake File";
            var defaultFileName = "DefaultImageReview.jpg";
            var defaultMs = new MemoryStream();
            var defautwriter = new StreamWriter(defaultMs);
            defautwriter.Write(defaultContent);
            defautwriter.Flush();
            defaultMs.Position = 0;
            imageFileDefaultMock.Setup(_ => _.OpenReadStream()).Returns(defaultMs);
            imageFileDefaultMock.Setup(_ => _.FileName).Returns(defaultFileName);
            imageFileDefaultMock.Setup(_ => _.Length).Returns(defaultMs.Length);

            this.imageFileDefault = imageFileDefaultMock.Object;

            var imageFileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            imageFileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            imageFileMock.Setup(_ => _.FileName).Returns(fileName);
            imageFileMock.Setup(_ => _.Length).Returns(ms.Length);

            this.imageFile = imageFileMock.Object;
        }
    }
}

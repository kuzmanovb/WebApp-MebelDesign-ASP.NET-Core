namespace MebelDesign71.Services.Data.Tests
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using MebelDesign71.Services.Data.Contracts;

    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    using Moq;

    using Xunit;

    public class FilesServiceTests
    {

        private readonly IFilesService filesService;
        private EfRepository<FileOnFileSystem> filesRepository;
        private ApplicationDbContext connection;
        private HostingEnvironment environment;

        public FilesServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            this.connection = new ApplicationDbContext(options);
            this.filesRepository = new EfRepository<FileOnFileSystem>(this.connection);
            this.environment = new HostingEnvironment();

            this.filesService = new FilesService(this.filesRepository, this.environment);
        }

        public void Dispose()
        {
            this.connection.Database.EnsureDeleted();
            this.connection.Dispose();
        }

        [Fact]
        public async Task GetFileByIdReturnCorrec()
        {

            var entityOne = this.connection.FileOnFileSystems.Add(new FileOnFileSystem());
            var entityTwo = this.connection.FileOnFileSystems.Add(new FileOnFileSystem());
            await this.connection.SaveChangesAsync();

            var getEntityOne = this.filesService.GetFileByIdFromFileSystem(entityOne.Entity.Id);
            var getEntityTwo = this.filesService.GetFileByIdFromFileSystem(entityTwo.Entity.Id);

            Assert.Equal(getEntityOne, getEntityOne);
            Assert.Equal(getEntityTwo, getEntityTwo);
            Assert.False(getEntityOne == getEntityTwo);
        }

        [Fact]
        public async Task GetFileByIdReturnNull()
        {
            var entityOne = this.connection.FileOnFileSystems.Add(new FileOnFileSystem());
            await this.connection.SaveChangesAsync();

            var getEntityOne = await this.filesService.GetFileByIdFromFileSystem("whatever");

            Assert.Null(getEntityOne);
        }

        [Fact]
        public async Task DeleteFileByIdReturnTrue()
        {
            var entityOne = this.connection.FileOnFileSystems.Add(new FileOnFileSystem());
            await this.connection.SaveChangesAsync();

            var entity = await this.filesService.GetFileByIdFromFileSystem(entityOne.Entity.Id);

            var result = await this.filesService.DeleteFileFromFileSystem(entity.Id);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteFileByIdReturnFalse()
        {
            var entityOne = this.connection.FileOnFileSystems.Add(new FileOnFileSystem());
            await this.connection.SaveChangesAsync();

            var result = await this.filesService.DeleteFileFromFileSystem("whatever");

            Assert.False(result);
        }

        [Fact]
        public async Task UploadToFileSystemExpectationCorrrectly()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            var fileId = await this.filesService.UploadToFileSystem(file, "test");

            var allRepo = this.filesRepository.All().FirstOrDefault();

            Assert.NotNull(allRepo);

        }
    }
}

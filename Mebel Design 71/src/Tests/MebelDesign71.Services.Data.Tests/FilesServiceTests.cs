namespace MebelDesign71.Services.Data.Tests
{
    using System.Threading.Tasks;

    using MebelDesign71.Data;
    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Data.Repositories;
    using Microsoft.AspNetCore.Hosting.Internal;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class FilesServiceTests
    {
        // DeleteFileFromFileSystem
        // GetFileByIdFromFileSystem
        // UploadToFileSystem





        [Fact]
        public async Task GetFileByIdReturnCorrec()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var entityOne = dbContext.FileOnFileSystems.Add(new FileOnFileSystem());
            var entityTwo = dbContext.FileOnFileSystems.Add(new FileOnFileSystem());
            var entityThree = dbContext.FileOnFileSystems.Add(new FileOnFileSystem());
            await dbContext.SaveChangesAsync();

            using var repository = new EfRepository<FileOnFileSystem>(dbContext);
            var httpContextAccessor = new HttpContextAccessor();
            var environment = new HostingEnvironment();
            var service = new FilesService(repository, httpContextAccessor, environment);

            var getEntityOne = service.GetFileByIdFromFileSystem(entityOne.Entity.Id);
            var getEntityTwo = service.GetFileByIdFromFileSystem(entityTwo.Entity.Id);
            var getEntityThree = service.GetFileByIdFromFileSystem(entityThree.Entity.Id);

            Assert.Equal(getEntityOne, getEntityOne);
            Assert.Equal(getEntityTwo, getEntityTwo);
            Assert.Equal(getEntityThree, getEntityThree);
        }

        [Fact]
        public async Task GetFileByIdReturnNull()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: "FileTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);

            var entityOne = dbContext.FileOnFileSystems.Add(new FileOnFileSystem());
            await dbContext.SaveChangesAsync();

            using var repository = new EfRepository<FileOnFileSystem>(dbContext);
            var httpContextAccessor = new HttpContextAccessor();
            var environment = new HostingEnvironment();
            var service = new FilesService(repository, httpContextAccessor, environment);

            var getEntityOne = await service.GetFileByIdFromFileSystem("someNumber");

            Assert.Null(getEntityOne);
        }


    }
}

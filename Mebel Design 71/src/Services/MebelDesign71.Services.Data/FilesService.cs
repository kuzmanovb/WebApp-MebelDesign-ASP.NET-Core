namespace MebelDesign71.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class FilesService : IFilesService
    {
        private const string EmptyString = "";

        private readonly IRepository<FileOnFileSystem> dbFileOnSystem;
        private readonly IHostingEnvironment environment;

        public FilesService(IRepository<FileOnFileSystem> dbFileOnSystem, IHostingEnvironment environment)
        {
            this.dbFileOnSystem = dbFileOnSystem;
            this.environment = environment;
        }

        public async Task<string> UploadToFileSystemAsync(IFormFile file, string folderInWwwRoot, string description = null, string userId = null)
        {

            var basePath = Path.Combine(this.environment.WebRootPath + "\\" + folderInWwwRoot + "\\");
            bool basePathExists = Directory.Exists(basePath);

            if (!basePathExists)
            {
                Directory.CreateDirectory(basePath);
            }

            var generator = new Random();

            string gen = generator.Next(1000).ToString();

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var filePath = Path.Combine(basePath, gen + file.FileName);
            var extension = Path.GetExtension(file.FileName);

            if (!File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var fileModel = new FileOnFileSystem
                {
                    CreatedOn = DateTime.UtcNow,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName,
                    UserId = userId,
                    Description = description,
                    FilePath = filePath,
                };

                await this.dbFileOnSystem.AddAsync(fileModel);
                await this.dbFileOnSystem.SaveChangesAsync();

                return fileModel.Id;
            }

            return EmptyString;
        }

        public async Task<FileOnFileSystem> GetFileByIdFromFileSystemAsync(string id)
        {
            var file = await this.dbFileOnSystem.All().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (file == null)
            {
                return null;
            }

            return file;
        }

        public async Task<bool> DeleteFileFromFileSystemAsync(string id)
        {
            var file = await this.dbFileOnSystem.All().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (file == null)
            {
                return false;
            }

            if (File.Exists(file.FilePath))
            {
                File.Delete(file.FilePath);
            }

            this.dbFileOnSystem.Delete(file);
            await this.dbFileOnSystem.SaveChangesAsync();

            return true;
        }

    }
}

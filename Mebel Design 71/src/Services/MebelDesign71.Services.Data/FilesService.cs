namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Files;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class FilesService : IFilesService
    {
        private readonly IRepository<FileOnFileSystem> dbFileOnSystem;

        public FilesService(IRepository<FileOnFileSystem> dbFileOnSystem)
        {
            this.dbFileOnSystem = dbFileOnSystem;
        }

        public async Task<bool> DeleteFileFromFileSystem(string id)
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

        public async Task<PropertiesToDownloadViewModel> PropertiesToDownloadFileFromFileSystem(string id)
        {
            var file = await this.dbFileOnSystem.All().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (file == null)
            {
                return null;
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            var fileToDownloadProperties = new PropertiesToDownloadViewModel
            {
                File = memory.ToArray(),
                Type = file.FileType,
                Name = file.Name,
                Extension = file.Extension,
            };

            return fileToDownloadProperties;
        }

        public async Task<bool> UploadToFileSystem(List<IFormFile> files, string folderInWwwRoot, string description = null)
        {
            var countToUpload = 0;
            var allFileCount = files.Count();

            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\" + folderInWwwRoot + "\\");
                bool basePathExists = Directory.Exists(basePath);

                if (!basePathExists)
                {
                    Directory.CreateDirectory(basePath);
                }

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
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
                        Description = description,
                        FilePath = filePath,
                    };

                    await this.dbFileOnSystem.AddAsync(fileModel);
                    await this.dbFileOnSystem.SaveChangesAsync();

                    countToUpload++;
                }
            }

            if (countToUpload == allFileCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using MebelDesign71.Data.Common.Repositories;
using MebelDesign71.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MebelDesign71.Services.Data
{
    public class FilesService : IFilesService
    {
        private readonly IRepository<FileOnFileSystem> dbFileOnSystem;

        public FilesService(IRepository<FileOnFileSystem> dbFileOnSystem)
        {
            this.dbFileOnSystem = dbFileOnSystem;
        }


        public async Task UploadToFileSystem(List<IFormFile> files, string folderInWwwRoot, string description = null)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\" + folderInWwwRoot + "\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);

                if (!basePathExists)
                {
                    Directory.CreateDirectory(basePath);
                }

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
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
                        FilePath = filePath
                    };

                    await this.dbFileOnSystem.AddAsync(fileModel);
                    await this.dbFileOnSystem.SaveChangesAsync();
                }
            }
        }
    }
}

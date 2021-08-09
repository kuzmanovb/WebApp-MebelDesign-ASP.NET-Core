﻿namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Service;
    using Microsoft.EntityFrameworkCore;

    public class ServicesService : IServicesService
    {
        private readonly IDeletableEntityRepository<Service> dbService;
        private readonly IFilesService filesService;

        public ServicesService(IDeletableEntityRepository<Service> dbService, IFilesService filesService)
        {
            this.dbService = dbService;
            this.filesService = filesService;
        }

        public async Task<int> CreateServiceAsync(ServiceInputModel input)
        {
            var headImageId = await this.filesService.UploadToFileSystemAsync(input.HeadImage, "images\\serviceImages", "Service Hade Image");
            string documentId = null;

            if (input.Document != null)
            {
                documentId = await this.filesService.UploadToFileSystemAsync(input.Document, "documents\\service\\official", "Service " + input.Name + " document");
            }

            var newService = new Service
            {
                Name = input.Name,
                Description = input.Description,
                HeadImageId = headImageId,
                DocumentId = documentId,
            };

            await this.dbService.AddAsync(newService);
            await this.dbService.SaveChangesAsync();

            return newService.Id;
        }

        public IEnumerable<ServiceInputModel> GetAllService()
        {
            var allServices = this.dbService.All()
                .Select(s => new ServiceInputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImagePath = RenameFilePath(s.HeadImage.FilePath),
                    DocumentId = s.DocumentId,
                    DocumentName = s.Document.Name,

                })
                .ToList();

            return allServices;
        }

        public IEnumerable<ServiceInputModel> GetAllServiceWithDeleted()
        {
            var allServices = this.dbService.AllWithDeleted()
               .Select(s => new ServiceInputModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Description = s.Description,
                   ImagePath = RenameFilePath(s.HeadImage.FilePath),
                   DocumentId = s.DocumentId,
                   DocumentName = s.Document.Name,
                   IsDeleted = s.IsDeleted == false ? "ДА" : "НЕ",
               })
               .ToList();

            return allServices;
        }

        public async Task<ServiceInputModel> GetServiceByIdAsync(int id)
        {
            var currentServices = await this.dbService.AllWithDeleted()
                .Where(s => s.Id == id)
                .Select(s => new ServiceInputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImagePath = RenameFilePath(s.HeadImage.FilePath),
                    DocumentId = s.DocumentId,
                    DocumentName = s.Document.Name,
                })
                .FirstOrDefaultAsync();

            return currentServices;
        }

        public async Task<ServiceViewModel> GetServiceByIdForViewAsync(int id)
        {
            var allServices = await this.dbService.All()
                .Where(s => s.Id == id)
                .Select(s => new ServiceViewModel
                {
                    Name = s.Name,
                    Description = s.Description.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray(),
                    ImagePath = RenameFilePath(s.HeadImage.FilePath),
                    HeadImageId = s.HeadImageId,
                    DocumentId = s.DocumentId,
                    DocumentName = s.Document.Name,
                })
                .FirstOrDefaultAsync();

            return allServices;
        }


        public async Task UpdateServiceAsync(ServiceInputModel input)
        {
            var currentService = this.dbService.All().FirstOrDefault(s => s.Id == input.Id);

            if (input.HeadImage != null)
            {
                var headImageId = await this.filesService.UploadToFileSystemAsync(input.HeadImage, "images\\serviceImages", "Service Hade Image");
                currentService.HeadImageId = headImageId;
            }

            if (input.Document != null)
            {
                var documentId = await this.filesService.UploadToFileSystemAsync(input.Document, "documents\\service\\official", "Service " + input.Name + "document");
                currentService.DocumentId = documentId;
            }

            if (currentService.Name != input.Name)
            {
                currentService.Name = input.Name;
            }

            if (currentService.Description != input.Description)
            {
                currentService.Description = input.Description;
            }

            this.dbService.Update(currentService);
            await this.dbService.SaveChangesAsync();
        }

        public async Task ChangeIsDeleteServiceAsync(int id)
        {
            var currentService = this.dbService.AllWithDeleted().Where(p => p.Id == id).FirstOrDefault();

            if (currentService.IsDeleted == true)
            {
                currentService.IsDeleted = false;
            }
            else
            {
                currentService.IsDeleted = true;
            }

            this.dbService.Update(currentService);
            await this.dbService.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var currentService = this.dbService.All().FirstOrDefault(p => p.Id == id);

            this.dbService.HardDelete(currentService);
            await this.dbService.SaveChangesAsync();

            await this.filesService.DeleteFileFromFileSystemAsync(currentService.HeadImageId);
            if (currentService.DocumentId != null)
            {
                await this.filesService.DeleteFileFromFileSystemAsync(currentService.DocumentId);
            }
        }

        public async Task DeleteDocumentAsync(int id)
        {
            var currentService = this.dbService.All().FirstOrDefault(p => p.Id == id);

            currentService.DocumentId = null;
            this.dbService.Update(currentService);
            await this.dbService.SaveChangesAsync();

            await this.filesService.DeleteFileFromFileSystemAsync(currentService.DocumentId);
        }

        private static string RenameFilePath(string fullPath)
        {
            var oldString = "\\";
            var newString = "/";
            var replaceSlashInFullPath = fullPath.Replace(oldString, newString);

            var getIndexStartWwwRoot = fullPath.LastIndexOf("wwwroot");
            var lengthWwwroot = "wwwroot".Length;

            if (getIndexStartWwwRoot >= 0)
            {

                var pathForView = replaceSlashInFullPath.Substring(getIndexStartWwwRoot + lengthWwwroot);
                return pathForView;
            }

            return replaceSlashInFullPath;
        }
    }
}

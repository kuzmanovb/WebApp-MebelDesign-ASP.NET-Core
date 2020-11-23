namespace MebelDesign71.Services.Data
{
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

        public async Task<ServiceViewModel> GetServiceByIdForView(int id)
        {
            //var allServices = this.dbService.All().ToList();

            //var allServicesView = new List<ServiceViewModel>();

            //foreach (var service in allServices)
            //{
            //    var decriptionList = service.Description.Split(new char[] { '.', '-' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            //    var newServiceViewModel = new ServiceViewModel
            //    {
            //        Name = service.Name,
            //        Description = decriptionList,
            //        HeadImageId = service.HeadImageId,
            //        DocumentId = service.DocumentId,
            //    };

            //    allServicesView.Add(newServiceViewModel);
            //}

            //return allServicesView;

            throw new System.NotImplementedException();
        }

        public async Task<ServiceInputModel> GetServiceById(int id)
        {
            var currentServices = await this.dbService.AllWithDeleted()
                .Where(s => s.Id == id)
                .Select(s => new ServiceInputModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImagePath = s.HeadImage.FilePath,
                    DocumentId = s.DocumentId,
                    DocumentName = s.Document.Name,
                })
                .FirstOrDefaultAsync();

            return currentServices;
        }

        public async Task<int> CreateService(ServiceInputModel input)
        {
            var headImageId = await this.filesService.UploadToFileSystem(input.HeadImage, "images\\serviceImages", "Service Hade Image");
            string documentId = null;

            if (input.Document != null)
            {
                documentId = await this.filesService.UploadToFileSystem(input.Document, "serviceDocuments", "Service " + input.Name + "document");
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

        public async Task UpdateService(ServiceInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public async Task ChangeIsDeleteService(int id)
        {
            throw new System.NotImplementedException();
        }


        private static string RenameFilePath(string fullPath)
        {
            var oldString = "\\";
            var newString = "/";
            var replaceSlashInFullPath = fullPath.Replace(oldString, newString);

            var getIndexStartWwwRoot = fullPath.IndexOf("wwwroot");
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

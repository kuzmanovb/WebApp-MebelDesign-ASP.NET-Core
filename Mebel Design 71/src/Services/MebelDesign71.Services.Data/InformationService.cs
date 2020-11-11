namespace MebelDesign71.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Information;

    public class InformationService : IInformationService
    {
        private readonly IRepository<FileOnFileSystem> dbFileOnSystem;
        private readonly IFilesService filesService;

        public InformationService(IRepository<FileOnFileSystem> dbFileOnSystem, IFilesService filesService)
        {
            this.dbFileOnSystem = dbFileOnSystem;
            this.filesService = filesService;
        }

        public async Task<string> AddRewiev(ReviewViewModel input)
        {

            FileOnFileSystem newPrfileImage;

            if (input.ImageFile.Length > 0)
            {
               await this.filesService.UploadToFileSystem(input.ImageFile, "ProfilImage")
            }
            
            var newReview = new Review 
            { 

            
            
            
            };
        }

        public Task<ICollection<ReviewViewModel>> GetAllReview()
        {
            throw new NotImplementedException();
        }
    }
}

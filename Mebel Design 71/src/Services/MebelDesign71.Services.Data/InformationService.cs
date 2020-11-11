namespace MebelDesign71.Services.Data
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Information;
    using Microsoft.EntityFrameworkCore;

    public class InformationService : IInformationService
    {
        private readonly IRepository<FileOnFileSystem> dbFileOnSystem;
        private readonly IRepository<Image> dbImage;
        private readonly IDeletableEntityRepository<Review> dbReview;
        private readonly IFilesService filesService;

        public InformationService(IRepository<Image> dbImage, IDeletableEntityRepository<Review> dbReview, IFilesService filesService)
        {
            this.dbImage = dbImage;
            this.dbReview = dbReview;
            this.filesService = filesService;
        }

        public async Task<string> AddRewiev(ReviewInputModel input)
        {

            int imageId = 0;

            if (input.ImageFile.Length > 0)
            {
                var fileId = await this.filesService.UploadToFileSystem(input.ImageFile, "ProfilImage");
                var newImage = new Image { ImageTitle = "ProfilImage", FileId = fileId };

                await this.dbImage.AddAsync(newImage);
                await this.dbImage.SaveChangesAsync();

                imageId = newImage.Id;
            }

            var newReview = new Review
            {
                Name = input.Name,
                ImageId = imageId,
                Description = input.Description,
            };

            await this.dbReview.AddAsync(newReview);
            await this.dbReview.SaveChangesAsync();

            return newReview.Id;

        }

        public async Task<ICollection<ReviewViewModel>> GetAllReview()
        {
            var allReview = await this.dbReview.All()
                .Where(r => r.IsDeleted == false)
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new ReviewViewModel
                {
                    Name = r.Name,
                    FilePath = r.Image.File.FilePath,
                    Description = r.Description,
                })
                .ToListAsync();

            return allReview;
        }
    }
}

namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Services.Data.Contracts;
    using MebelDesign71.Web.ViewModels.Information;

    using Microsoft.EntityFrameworkCore;

    public class InformationService : IInformationService
    {

        private readonly IRepository<ImageToReview> dbImage;
        private readonly IDeletableEntityRepository<Review> dbReview;
        private readonly IFilesService filesService;
        private readonly IHtmlSanitizer sanitizer;

        public InformationService(IRepository<ImageToReview> dbImage, IDeletableEntityRepository<Review> dbReview, IFilesService filesService, IHtmlSanitizer sanitizer)
        {
            this.dbImage = dbImage;
            this.dbReview = dbReview;
            this.filesService = filesService;
            this.sanitizer = sanitizer;
        }

        public async Task<string> AddRewievAsync(ReviewInputModel input)
        {

            int imageId = this.dbImage.All().Where(i => i.File.Name == "DefaultImageReview").First().Id;

            if (input.ImageFile != null)
            {
                var fileId = await this.filesService.UploadToFileSystem(input.ImageFile, "images\\profilImages", "User Image To Review", input.UserId);

                if (!string.IsNullOrEmpty(fileId))
                {
                    var newImage = new ImageToReview { FileId = fileId };

                    await this.dbImage.AddAsync(newImage);
                    await this.dbImage.SaveChangesAsync();

                    imageId = newImage.Id;
                }
            }

            var newReview = new Review
            {
                Name = this.sanitizer.Sanitize(input.Name),
                ImageId = imageId,
                UserId = input.UserId,
                Description = this.sanitizer.Sanitize(input.Description),
            };

            await this.dbReview.AddAsync(newReview);
            await this.dbReview.SaveChangesAsync();

            return newReview.Id;
        }

        public async Task<ICollection<ReviewViewModel>> GetAllReviewAsync()
        {
            var allReview = await this.dbReview.All()
                .OrderBy(r => r.CreatedOn)
                .Select(r => new ReviewViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    FilePath = RenameFilePath(r.Image.File.FilePath),
                    Description = r.Description,
                })
                .ToListAsync();

            return allReview;
        }

        public async Task DeleteReviewAsync(string id)
        {
            var currentReview = this.dbReview.All().FirstOrDefault(r => r.Id == id);
            this.dbReview.HardDelete(currentReview);
            await this.dbReview.SaveChangesAsync();

            var profilImage = this.dbImage.All().FirstOrDefault(i => i.Id == currentReview.ImageId);
            int defaultImageId = this.dbImage.All().Where(i => i.File.Name == "DefaultImageReview").First().Id;

            if (profilImage.Id != defaultImageId)
            {
                this.dbImage.Delete(profilImage);
                await this.dbImage.SaveChangesAsync();

                await this.filesService.DeleteFileFromFileSystem(profilImage.FileId);
            }
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

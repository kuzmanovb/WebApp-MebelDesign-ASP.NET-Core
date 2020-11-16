namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Common.Repositories;
    using MebelDesign71.Data.Models;
    using MebelDesign71.Web.ViewModels.Information;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;

    public class InformationService : IInformationService
    {

        private readonly IRepository<ImageToReview> dbImage;
        private readonly IDeletableEntityRepository<Review> dbReview;
        private readonly IFilesService filesService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public InformationService(IRepository<ImageToReview> dbImage, IDeletableEntityRepository<Review> dbReview, IFilesService filesService, IHttpContextAccessor httpContextAccessor)
        {
            this.dbImage = dbImage;
            this.dbReview = dbReview;
            this.filesService = filesService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> AddRewiev(ReviewInputModel input)
        {

            int imageId = this.dbImage.All().Where(i => i.File.Name == "DefaultImageReview").First().Id;

            if (input.ImageFile != null)
            {
                var fileId = await this.filesService.UploadToFileSystem(input.ImageFile, "images/profilImages");

                if (!string.IsNullOrEmpty(fileId))
                {
                    var newImage = new ImageToReview { FileId = fileId };

                    await this.dbImage.AddAsync(newImage);
                    await this.dbImage.SaveChangesAsync();

                    imageId = newImage.Id;
                }
            }

            var userId = this.httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newReview = new Review
            {
                Name = input.Name,
                ImageId = imageId,
                UserId = userId,
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
                .OrderBy(r => r.CreatedOn)
                .Select(r => new ReviewViewModel
                {
                    Name = r.Name,
                    FilePath = RenameFilePath(r.Image.File.FilePath),
                    Description = r.Description,
                })
                .ToListAsync();

            return allReview;
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

                var pathForView = "~" + replaceSlashInFullPath.Substring(getIndexStartWwwRoot + lengthWwwroot);
                return pathForView;
            }

            return replaceSlashInFullPath;

        }
    }
}

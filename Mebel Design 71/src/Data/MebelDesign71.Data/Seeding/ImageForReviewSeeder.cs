namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using MebelDesign71.Data.Models;
    using Microsoft.AspNetCore.Hosting;

    internal class ImageForReviewSeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.ImageToReviews.Any())
            {
                return;
            }

            var imageFile = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "DefaultFotoReview",
                UserId = null,
                Description = "Default photo in Review",
                FilePath = "~/ProfilImage/DefaultFotoReview.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFile);
            await dbContext.SaveChangesAsync();

            var fileId = imageFile.Id;

            await dbContext.ImageToReviews.AddAsync(new ImageToReview { FileId = fileId });

        }
    }
}

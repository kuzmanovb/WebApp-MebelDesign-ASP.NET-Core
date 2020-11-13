namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;

    internal class ImageForReviewSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.ImageToReviews.Any())
            {
                return;
            }

            // Add Default Image
            var imageFile = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "DefaultImageReview",
                UserId = null,
                Description = "Default image in Review",
                FilePath = "~/profilImage/DefaultFotoReview.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFile);

            var fileId = imageFile.Id;

            await dbContext.ImageToReviews.AddAsync(new ImageToReview { FileId = fileId });


            // Add First Persom Image
            var imageFileOne = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "FirstPersonImageReview",
                UserId = null,
                Description = "First person image in Review",
                FilePath = "~/profilImage/Person1.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileOne);

            var fileOneId = imageFileOne.Id;

            await dbContext.ImageToReviews.AddAsync(new ImageToReview { FileId = fileOneId });

            // Add Second Persom Image
            var imageFileTwo = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "SecondPersonImageReview",
                UserId = null,
                Description = "Second person image in Review",
                FilePath = "~/profilImage/Person2.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileTwo);

            var fileTwoId = imageFileTwo.Id;

            await dbContext.ImageToReviews.AddAsync(new ImageToReview { FileId = fileTwoId });


        }
    }
}

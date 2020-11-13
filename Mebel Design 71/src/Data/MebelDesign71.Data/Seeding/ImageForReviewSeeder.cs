namespace MebelDesign71.Data.Seeding
{
    using MebelDesign71.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ImageForReviewSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ImageToReviews.Any())
            {
                return;
            }

            await dbContext.FileOnFileSystems.AddAsync(new FileOnFileSystem { });
          
        }
    }
}

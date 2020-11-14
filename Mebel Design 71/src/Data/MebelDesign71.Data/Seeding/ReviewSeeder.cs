namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class ReviewSeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Reviews.Any())
            {
                return;
            }

            var imageOne = dbContext.ImageToReviews.Where(n => n.File.Name == "FirstPersonImageReview").First();
            var descriptionOne = "От заплануването на кухнята ни до изпълнението й, бе показан голям професионализъм. Изработена с качествени материали. Добър екип. Препоръчвам.";
            var nameOne = "сем. Йовчеви";
            await dbContext.Reviews.AddAsync(new Review { Name = nameOne, Description = descriptionOne, ImageId = imageOne.Id});


            var imageTwo = dbContext.ImageToReviews.Where(n => n.File.Name == "SecondPersonImageReview").First();
            var descriptionTwo = "Благодарим за страхотната работа! След 5 месеца проучвате на фирми за мебели, Ви открихме и бихме Ви препоръчали на всички! Коректност, спазени срокове, функционални препоръки за мебелите - всичко беше на ниво! След гардероба и обзавеждането за склада и антрето, започваме да събираме идеи за хола и детската стая и със сигурност бихме поръчали отново при Вас!";
            var nameTwo = "Александър Малинов";
            await dbContext.Reviews.AddAsync(new Review { Name = nameTwo, Description = descriptionTwo, ImageId = imageTwo.Id});
        }
    }
}

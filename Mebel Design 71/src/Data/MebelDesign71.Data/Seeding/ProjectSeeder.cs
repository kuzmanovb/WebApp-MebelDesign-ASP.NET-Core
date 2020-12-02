namespace MebelDesign71.Data.Seeding
{
    using MebelDesign71.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProjectSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Projects.Any())
            {
                return;
            }

            var description = "С мебелите които правим се стремим да създаваме пространства, които да изразяват индивидуалността и стила на всеки наш клиент. " +
                              "Основната ни цел е да разберем в дълбочина желанията и потребностите на нашите клиенти и да предложим оригинални решения, " +
                              "които да покриват и най-високите изисквания по отношение на качество, дизайн, вкус и бюджет. " +
                              "Целта ни е всеки клиент да получи своите мечтани и качествени мебели по поръчка и те да издържи на теста на времето.";



            // Add Kitchen
            var imageFileToKitchen = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "KitchenProjectImage",
                UserId = null,
                Description = "Kitchen Head Image",
                FilePath = "/images/projectImages/Kitchen.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToKitchen);


            var kitchenProject = new Project
            {
                Name = "Кухни",
                Description = description,
                HeadImageId = imageFileToKitchen.Id,
            };

            await dbContext.Projects.AddAsync(kitchenProject);
            await dbContext.SaveChangesAsync();


            // Add Living Room
            var imageFileToLivingRoom = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "LivingRoomProjectImage",
                UserId = null,
                Description = "Living Room Head Image",
                FilePath = "/images/projectImages/LivingRoom.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToLivingRoom);

            var livingRoomProject = new Project
            {
                Name = "Дневни",
                Description = description,
                HeadImageId = imageFileToLivingRoom.Id,
            };

            await dbContext.Projects.AddAsync(livingRoomProject);
            await dbContext.SaveChangesAsync();



            // Add Bedroom
            var imageFileToBedroom = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "BedroomProjectImage",
                UserId = null,
                Description = "Bedroom Head Image",
                FilePath = "/images/projectImages/Bedroom.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToBedroom);

            var bedroomProject = new Project
            {
                Name = "Спални",
                Description = description,
                HeadImageId = imageFileToBedroom.Id,
            };

            await dbContext.Projects.AddAsync(bedroomProject);
            await dbContext.SaveChangesAsync();

            // Add Children Room
            var imageFileToChildrenRoom = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "ChildrenRoomProjectImage",
                UserId = null,
                Description = "Children Room Head Image",
                FilePath = "/images/projectImages/ChildrenRoom.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToChildrenRoom);

            var childrenRoomProject = new Project
            {
                Name = "Детски",
                Description = description,
                HeadImageId = imageFileToChildrenRoom.Id,
            };

            await dbContext.Projects.AddAsync(childrenRoomProject);
            await dbContext.SaveChangesAsync();

            // Add Wardrobe
            var imageFileToWardrobe = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "WardrobeProjectImage",
                UserId = null,
                Description = "Wardrobe Head Image",
                FilePath = "/images/projectImages/Wardrobe.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToWardrobe);

            var wardrobeProject = new Project
            {
                Name = "Гардероби",
                Description = description,
                HeadImageId = imageFileToWardrobe.Id,
            };

            await dbContext.Projects.AddAsync(wardrobeProject);
            await dbContext.SaveChangesAsync();

            // Add Office
            var imageFileToOffice = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "OfficeProjectImage",
                UserId = null,
                Description = "Office Head Image",
                FilePath = "/images/projectImages/Office.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToOffice);

            var officeProject = new Project
            {
                Name = "Офиси",
                Description = description,
                HeadImageId = imageFileToOffice.Id,
            };

            await dbContext.Projects.AddAsync(officeProject);
            await dbContext.SaveChangesAsync();

            // Add Shop
            var imageFileToShop = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "ShopProjectImage",
                UserId = null,
                Description = "Shop Head Image",
                FilePath = "/images/projectImages/Shop.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToShop);

            var shopProject = new Project
            {
                Name = "Търговски обекти",
                Description = description,
                HeadImageId = imageFileToShop.Id,
            };

            await dbContext.Projects.AddAsync(shopProject);
            await dbContext.SaveChangesAsync();
        }
    }
}

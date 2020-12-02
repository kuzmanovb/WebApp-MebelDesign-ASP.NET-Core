namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;

    public class ServiceSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Services.Any())
            {
                return;
            }

            //// Add Service For Custom Furniture

            var imageFileToCustomFurniture = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "CustomFurnitureImage",
                UserId = null,
                Description = "Custom Furniture Head Image",
                FilePath = "/images/serviceImages/service_1.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToCustomFurniture);


            var customFurniture = new Service
            {
                Name = "Мебели по поръчка",
                HeadImageId = imageFileToCustomFurniture.Id,
                Description = " Повече от 15 г. изработваме мебели:\r\n– по индивидуален проект на клиент. \r\n– по Ваша скица и размери\r\n– разработваме Вашата идея като Ви помагаме с нашия опит и усещане за функционалност\r\nМебелите които изработваме изглеждат страхотно, притежават устойчивост за влага и топлина, почистват се лесно. Това е от голямо значение особено в помещения които се използват всекидневно и ежечасно. \r\nНашите клиенти се радват на творческа свобода. Станете сами проектанти и дизайнери, проектирайки своите мебели, така както сами искате да изглеждат. \r\nИзразете себе си като изберете най-предпочитания десен за вашето помещение. Тъмни или светли декори в различни повърхности, разказват своите неповторими истории. \r\nСвържете се с нас за да запишете час за оглед или в раздела „Моите поръчки“ може да ни изпратите скица или проект, и ние че ви дадем ориентировъчна цена за вашите мебели. Крайната цена може да бъде определена след уточняване на всички елементи по поръчката, вид плоскости, обков и т.н.",

            };

            await dbContext.Services.AddAsync(customFurniture);

            //// Add Service For Cutting And Edging

            var imageFileToCuttingAndEdging = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "CuttingAndEdgingImage",
                UserId = null,
                Description = "Cutting And Edging Head Image",
                FilePath = "/images/serviceImages/service_2.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToCuttingAndEdging);

            var cuttingAndEdging = new Service
            {
                Name = "Разкрой и кантиране на всички видове ПДЧ и МДФ плоскости",
                HeadImageId = imageFileToCuttingAndEdging.Id,
                Description = "С нашите модерни и нови машини, можем да гарантираме разкрой и кантиране с висока точност и превъзходно качество, на всички видове ПДЧ и МДФ плоскости, кухненски плотове и гърбове.\r\nИзисквания при поръчка за разкрой: \r\n1. Размерите се дават в мм в следната последователност: \r\n-височина или размер, по който ще вървят дървесните шарки, ако има такива; \r\n-ширина; \r\n-брой детайли; \r\n-кантиране /дълга, къса страна, дебелина на канта/.\r\n2. При наличие на кантиране да се дава размер след приспадане на канта. \r\n Поръчката може да бъдат направена онлайн като попълните нашата бланка за разкрой и кантиране и я прикачите към поръчка за тази услуга в раздела „Моите поръчки“ или предадете на място. \r\n По долу може да свалите бланка за поръчка. \r\n",

            };

            await dbContext.Services.AddAsync(cuttingAndEdging);

            //// Add Service For Drilling

            var imageFileToDrilling = new FileOnFileSystem
            {
                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = "DrillingImage",
                UserId = null,
                Description = "Drilling Head Image",
                FilePath = "/images/serviceImages/service_3.jpg",
            };

            await dbContext.FileOnFileSystems.AddAsync(imageFileToDrilling);

            var drilling = new Service
            {
                Name = "Разпробиване на отвори за панти, минификсове и  дибли",
                HeadImageId = imageFileToDrilling.Id,
                Description = "Вече предлагаме услугите за разпробиване на отвори за панти, минификсове и  дибли. Което съчетано с разкроят и кантирането което предлагаме, получавате елементи готови за сглобяване. \r\n Работим с чисто нови немски машини и предлагаме перфектно качество и изработка.\r\n Освен на частни клиенти, изпълняваме поръчки и на фирми, магазини, които нямат собствено производство. \r\n Поръчката може да бъдат направена онлайн като попълните нашата бланка за разкрой, кантиране и пробиване и я прикачите към поръчка за тази услуга в раздела „Моите поръчки“ или предадете на място. \r\n По долу може да свалите бланка за поръчка. \r\n",

            };

            await dbContext.Services.AddAsync(drilling);

            await dbContext.SaveChangesAsync();
        }
    }
}

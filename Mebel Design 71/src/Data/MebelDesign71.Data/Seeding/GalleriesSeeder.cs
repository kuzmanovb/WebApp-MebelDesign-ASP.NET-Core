namespace MebelDesign71.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;

    public class GalleriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.GalleryProjects.Any())
            {
                return;
            }

            var allProjecrs = dbContext.Projects.ToArray();

            foreach (var project in allProjecrs)
            {
                var images = new List<FileOnFileSystem>();

                if (project.Name == "Кухни")
                {
                    var name = "GalleryKitchenImage";
                    var description = "Image To Kitchen Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Кухни/Kitchen-6.jpg"));
                }
                else if (project.Name == "Дневни")
                {
                    var name = "GalleryLivingRoomImage";
                    var description = "Image To Living Room Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Дневни/Living_Room-6.jpg"));
                }
                else if (project.Name == "Спални")
                {
                    var name = "GalleryBedroomImage";
                    var description = "Image To Bedroom Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Спални/Bedroom-6.jpg"));
                }
                else if (project.Name == "Детски")
                {
                    var name = "GalleryChildrenRoomImage";
                    var description = "Image To Children Room Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Детски/Children_Room-6.jpg"));
                }
                else if (project.Name == "Гардероби")
                {
                    var name = "GalleryWardrobeImage";
                    var description = "Image To Wardrobe Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Гардероби/Wardrobe-6.jpg"));
                }
                else if (project.Name == "Офиси")
                {
                    var name = "GalleryOfficeImage";
                    var description = "Image To Office Gallery";

                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-1.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-2.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-3.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-4.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-5.jpg"));
                    images.Add(this.CreateFileImage(name, description, "/images/projectImages/Офиси/Office-6.jpg"));
                }

                foreach (var i in images)
                {
                    dbContext.FileOnFileSystems.Add(i);
                    dbContext.GalleryProjects.Add(new GalleryProject { FileId = i.Id, ProjectId = project.Id });
                }

                await dbContext.SaveChangesAsync();
            }
        }

        private FileOnFileSystem CreateFileImage(string name, string description, string filePath)
        {
            var imageFile = new FileOnFileSystem
            {

                CreatedOn = DateTime.UtcNow,
                FileType = "image/jpeg",
                Extension = ".jpg",
                Name = name,
                UserId = null,
                Description = description,
                FilePath = filePath,
            };

            return imageFile;
        }
    }
}

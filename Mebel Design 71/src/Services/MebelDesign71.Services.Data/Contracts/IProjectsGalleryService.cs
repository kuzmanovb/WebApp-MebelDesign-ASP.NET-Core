namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MebelDesign71.Web.ViewModels.ProjectsImage;

    public interface IProjectsGalleryService
    {
        Task<int> AddImageToGallery(ImageInputModel input);

        Task<ICollection<ViewImageModel>> GetGallery(int id);

        Task DeleteImage(int id);

    }
}

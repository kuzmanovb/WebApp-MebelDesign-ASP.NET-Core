namespace MebelDesign71.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MebelDesign71.Web.ViewModels.ProjectsImage;

    public interface IProjectsGalleryService
    {
        Task<int> AddImageToGalleryAsync(ImageInputModel input);

        Task<ICollection<ViewImageModel>> GetGalleryAsync(int id);

        Task DeleteImageAsync(int id);

    }
}

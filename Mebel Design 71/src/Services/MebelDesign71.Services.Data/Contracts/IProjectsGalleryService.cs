namespace MebelDesign71.Services.Data.Contracts
{
    using MebelDesign71.Web.ViewModels.Projects;
    using System.Threading.Tasks;

    public interface IGalleriesService
    {
        Task<int> AddImageToGallery(ImageInputModel input);

        Task GetGallery(int id);

        Task DeleteImage(int id);

    }
}

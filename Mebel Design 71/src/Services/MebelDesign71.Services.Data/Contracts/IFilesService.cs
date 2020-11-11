namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MebelDesign71.Web.ViewModels.Files;
    using MebelDesign71.Web.ViewModels.Information;
    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        Task<string> UploadToFileSystem(IFormFile files, string folderInWwwRoot, string description = null);

        Task<PropertiesToDownloadViewModel> PropertiesToDownloadFileFromFileSystem(string id);

        Task<bool> DeleteFileFromFileSystem(string id);
    }
}

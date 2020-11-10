namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using MebelDesign71.Web.ViewModels.Files;
    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        Task<bool> UploadToFileSystem(List<IFormFile> files, string folderInWwwRoot, string description = null);

        Task<PropertiesToDownloadViewModel> PropertiesToDownloadFileFromFileSystem(string id);

        Task<bool> DeleteFileFromFileSystem(string id);
    }
}

namespace MebelDesign71.Services.Data
{
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        Task<string> UploadToFileSystem(IFormFile files, string folderInWwwRoot, string description = null);

        Task<FileOnFileSystem> GetFileByIdFromFileSystem(string id);

        Task<bool> DeleteFileFromFileSystem(string id);
    }
}

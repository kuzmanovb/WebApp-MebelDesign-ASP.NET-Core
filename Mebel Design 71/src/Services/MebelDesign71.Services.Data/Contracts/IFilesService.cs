namespace MebelDesign71.Services.Data.Contracts
{
    using System.Threading.Tasks;

    using MebelDesign71.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        Task<string> UploadToFileSystemAsync(IFormFile files, string folderInWwwRoot, string description = null, string userId = null);

        Task<FileOnFileSystem> GetFileByIdFromFileSystemAsync(string id);

        Task<bool> DeleteFileFromFileSystemAsync(string id);
    }
}

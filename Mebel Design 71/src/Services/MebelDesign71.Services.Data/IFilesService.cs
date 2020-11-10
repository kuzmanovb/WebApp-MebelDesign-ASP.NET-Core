namespace MebelDesign71.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IFilesService
    {
        Task UploadToFileSystem(List<IFormFile> files, string folderInWwwRoot, string description = null);

    }
}

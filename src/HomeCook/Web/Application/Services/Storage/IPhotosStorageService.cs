using Application.Models.Storage;

namespace Application.Services.Storage;

public interface IPhotosStorageService
{
    Task<StorageFile> GetFile(string path);
    Task AddFile(StorageFile file);
}
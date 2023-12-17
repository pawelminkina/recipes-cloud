using Application.Models.Storage;
using Application.Services.Storage;
using Azure.Storage.Blobs;
using Infrastructure.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace Infrastructure.Storage.Azure;

public class AzurePhotosStorageService : IPhotosStorageService
{
    private readonly IOptions<AzureStorageAccountConfig> _options;

    public AzurePhotosStorageService(IOptions<AzureStorageAccountConfig> options)
    {
        _options = options;
    }
    public async Task<StorageFile> GetFile(string path)
    {
        var result = new StorageFile() {Path = path};
        var client = new BlobClient(_options.Value.ConnectionString, _options.Value.PhotosContainerName, path);

        if (!client.Exists())
        {
            throw new ArgumentException($"There was no file with given path in the system, path: {path}");
        }

        await client.DownloadToAsync(result.Content);

        return result;
    }

    public async Task AddFile(StorageFile file)
    {
        var client = new BlobClient(_options.Value.ConnectionString, _options.Value.PhotosContainerName, file.Path);

        if (client.Exists())
        {
            throw new ArgumentException($"There is already file with that name in the system, path: {file.Path}");
        }

        await client.UploadAsync(file.Content);
    }
}
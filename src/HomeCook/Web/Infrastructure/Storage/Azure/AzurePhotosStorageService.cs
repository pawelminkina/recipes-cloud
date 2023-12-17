using Application.Models.Storage;
using Application.Services.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Infrastructure.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;
using Azure.Storage.Blobs.Specialized;

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
        var result = new StorageFile() { Path = path };
        var client = new BlobClient(_options.Value.ConnectionString, _options.Value.PhotosContainerName, path);

        if (!client.Exists())
        {
            throw new ArgumentException($"There was no file with given path in the system, path: {path}");
        }
        if (client.CanGenerateSasUri)
        {
            // Create a SAS token that's valid for one minute
            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = client.GetParentBlobContainerClient().Name,
                BlobName = client.Name,
                Resource = "b"
            };

            sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(5);
            sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);

            Uri sasURI = client.GenerateSasUri(sasBuilder);

            result.ContentUrl = sasURI.OriginalString;
        }

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
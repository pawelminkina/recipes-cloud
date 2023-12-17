using Application.Models.Storage;
using Application.Services.Api;
using Application.Services.Storage;

namespace Application.Services.Files;

public class PhotoService : IPhotoService
{
    private readonly IPhotosStorageService _storageService;
    private readonly IPhotoApiService _apiPhotoService;

    public PhotoService(IPhotosStorageService storageService, IPhotoApiService apiPhotoService)
    {
        _storageService = storageService;
        _apiPhotoService = apiPhotoService;
    }
    public async Task<RecipePhotoDto> GetPhoto(Guid photoId)
    {
        var response = await _apiPhotoService.GetPhoto(photoId);
        var photo = await _storageService.GetFile(response!.Path);

        return new RecipePhotoDto()
        {
            Id = response.Id,
            PhotoUrl = photo.ContentUrl,
        };
    }

    public async Task<Guid> AddPhoto(Stream photo, string extension)
    {
        var path = $"{Guid.NewGuid()}{extension}";
        await _storageService.AddFile(new StorageFile()
        {
            Content = photo,
            Path = path
        });

        var id = await _apiPhotoService.AddPhoto(path);
        return id;
    }
}
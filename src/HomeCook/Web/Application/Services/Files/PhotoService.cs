using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Application.Config;
using Application.Models.Storage;
using Application.Services.Storage;
using Microsoft.Extensions.Options;

namespace Application.Services.Files;

public class PhotoService : IPhotoService
{
    private readonly IPhotosStorageService _storageService;
    private readonly IOptions<ServicesConfig> _serviceOptions;
    private readonly HttpClient _httpClient;

    public PhotoService(IPhotosStorageService storageService, IHttpClientFactory httpClientFactory, IOptions<ServicesConfig> serviceOptions)
    {
        _storageService = storageService;
        _serviceOptions = serviceOptions;
        _httpClient = httpClientFactory.CreateClient();
    }
    public async Task<RecipePhotoDto> GetPhoto(Guid photoId)
    {
        var getPhotoUrl = $"{_serviceOptions.Value.FileServiceBaseUrl}/Photo/{photoId}";
        var response = await _httpClient.GetFromJsonAsync<GetPhotoDto>(getPhotoUrl);

        var photo = await _storageService.GetFile(response!.Path);

        return new RecipePhotoDto()
        {
            Id = response.Id,
            Photo = photo.Content,
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

        var addPhotoUrl = $"{_serviceOptions.Value.FileServiceBaseUrl}/Photo";
        var response = await _httpClient.PostAsync(addPhotoUrl, new StringContent(JsonSerializer.Serialize(new PhotoToAddDto()
        {
            Path = path
        }), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(stringContent))
        {
            throw new InvalidOperationException("Adding photo failed and no id was returned");
        }

        return JsonSerializer.Deserialize<Guid>(stringContent);
    }
}
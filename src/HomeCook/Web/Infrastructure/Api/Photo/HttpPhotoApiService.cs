using Application.Services.Api;
using Application.Services.Files;
using Infrastructure.Config;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Infrastructure.Api.Photo;

public class HttpPhotoApiService : IPhotoApiService
{
    private readonly IOptions<ServicesConfig> _serviceOptions;
    private HttpClient _httpClient;

    public HttpPhotoApiService(IOptions<ServicesConfig> serviceOptions, IHttpClientFactory httpClientFactory)
    {
        _serviceOptions = serviceOptions;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<GetPhotoDto> GetPhoto(Guid photoId)
    {
        var getPhotoUrl = $"{_serviceOptions.Value.FileServiceBaseUrl}/api/Photo/{photoId}";
        var response = await _httpClient.GetFromJsonAsync<GetPhotoDto>(getPhotoUrl);
        return response!;
    }

    public async Task<Guid> AddPhoto(string path)
    {
        var addPhotoUrl = $"{_serviceOptions.Value.FileServiceBaseUrl}/api/Photo";
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
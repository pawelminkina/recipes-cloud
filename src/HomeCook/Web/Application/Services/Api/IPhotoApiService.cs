using Application.Services.Files;

namespace Application.Services.Api;

public interface IPhotoApiService
{
    Task<GetPhotoDto> GetPhoto(Guid photoId);
    Task<Guid> AddPhoto(string path);
}
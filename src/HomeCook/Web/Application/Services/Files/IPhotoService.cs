using Application.Models.Storage;

namespace Application.Services.Files;

public interface IPhotoService
{
    Task<RecipePhotoDto> GetPhoto(Guid photoId);
    Task<Guid> AddPhoto(Stream photo, string extension);
}
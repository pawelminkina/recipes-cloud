namespace Application.Queries.GetPhoto;

public record Photo
{
    public Guid Id { get; set; }
    public DateTime TimeUploadedUtc { get; set; }
    public string Path { get; set; }

    public static Photo CreateFromDomain(Domain.Photo photo) => new()
    {
        Path = photo.Path,
        TimeUploadedUtc = photo.TimeUploadedUtc,
        Id = photo.Id
    };
}
namespace Application.Services.Files;

public class GetPhotoDto
{
    public Guid Id { get; set; }
    public DateTime TimeUploadedUtc { get; set; }
    public string Path { get; set; } = string.Empty;
}
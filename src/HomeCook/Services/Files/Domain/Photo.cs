namespace Domain;

public record Photo
{
    public Guid Id { get; internal set; }
    public DateTime TimeUploadedUtc { get; } = DateTime.UtcNow;
    public string Path { get; init; }
}
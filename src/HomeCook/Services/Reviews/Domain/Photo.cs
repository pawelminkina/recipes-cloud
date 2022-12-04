namespace Domain;

public record Photo
{
    public Guid Id { get; }
    public DateTime TimeUploadedUtc { get; } = DateTime.UtcNow;
    public string Path { get; init; }
    public Review? RelatedReview { get; }
}
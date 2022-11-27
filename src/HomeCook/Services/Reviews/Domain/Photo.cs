namespace Domain;

public record Photo
{
    public Photo()
    {
        TimeUploadedUtc = DateTime.UtcNow;
    }
    public Guid Id { get; }
    public DateTime TimeUploadedUtc { get; }
    public string Path { get; init; }
    public Review? RelatedReview { get; }
}
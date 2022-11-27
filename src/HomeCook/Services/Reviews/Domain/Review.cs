namespace Domain;

public record Review
{
    public Review()
    {
        TimeCreatedUtc = DateTime.UtcNow;
    }
    public Guid Id { get; }
    public Guid IdOfRelatedRecipe { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime TimeCreatedUtc { get; }
    public ICollection<Photo> Photos { get; init; }
}
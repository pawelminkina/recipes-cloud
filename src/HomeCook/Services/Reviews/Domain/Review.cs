namespace Domain;

public record Review
{

    public Guid Id { get; }
    public Guid IdOfRelatedRecipe { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public DateTime TimeCreatedUtc { get; } = DateTime.UtcNow;
    public ICollection<Photo> Photos { get; init; }
}
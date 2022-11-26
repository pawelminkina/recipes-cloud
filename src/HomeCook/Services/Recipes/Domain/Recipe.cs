namespace Domain;

public record Recipe
{
    public Guid Id { get; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorEmail { get; init; }
    public string MainPhotoPath { get; init; }
}
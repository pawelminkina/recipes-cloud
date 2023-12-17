namespace Application.Models.Recipes;

public record RecipeToAddDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorEmail { get; init; }
    public Stream MainPhoto { get; init; }
    public string FileExtension { get; init; }
}
namespace Application.Commands.CreateRecipe;

public record RecipeToCreate
{
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorEmail { get; init; }
    public Guid MainPhotoId { get; init; }
}
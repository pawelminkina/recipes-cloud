namespace Application.Services.Recipe;

public class RecipeToAdd
{
    public string Title { get; init; }
    public string Content { get; init; }
    public string AuthorEmail { get; init; }
    public Guid MainPhotoId { get; init; }
}
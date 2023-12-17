namespace Application.Services.Recipe;

public record RecipeToGet
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AuthorEmail { get; set; }
    public Guid MainPhotoId { get; set; }

}
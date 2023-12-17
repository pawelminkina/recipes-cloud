namespace Application.Services.Recipe;

public record DetailedRecipeToGet
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorEmail { get; set; }
    public Guid MainPhotoId { get; set; }
}
namespace Application.Queries.AllRecipes;

public record Recipe
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AuthorEmail { get; set; }
    public Guid MainPhotoId { get; set; }
}
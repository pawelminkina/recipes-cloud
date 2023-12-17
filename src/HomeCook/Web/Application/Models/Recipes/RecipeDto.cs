namespace Application.Models.Recipes;

public record RecipeDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string AuthorEmail { get; set; }
    public Stream MainPhoto { get; set; }
}
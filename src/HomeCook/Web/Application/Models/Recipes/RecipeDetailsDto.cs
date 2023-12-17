namespace Application.Models.Recipes;

public record RecipeDetailsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorEmail { get; set; }
    public Stream MainPhoto { get; set; }
}
using Domain;

namespace Application.Queries.DetailedRecipe;

public class RecipeDetails
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorEmail { get; set; }
    public Guid MainPhotoId { get; set; }

    public static RecipeDetails MapFromDomain(Recipe recipe) => new()
    {
        AuthorEmail = recipe.AuthorEmail,
        Content = recipe.Content,
        Id = recipe.Id,
        MainPhotoId = recipe.MainPhotoId,
        Title = recipe.Title
    };
}
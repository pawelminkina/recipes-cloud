using Application.Models.Recipes;

namespace Application.Services.Recipe;

public interface IRecipeService
{
    Task<List<RecipeDto>> GetAllRecipes();
    Task<RecipeDetailsDto> GetRecipeDetails(Guid id);
    Task<Guid> AddRecipe(RecipeToAddDto recipeToAddDto);
}
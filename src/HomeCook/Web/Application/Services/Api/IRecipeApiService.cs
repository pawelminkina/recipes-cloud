using Application.Services.Recipe;

namespace Application.Services.Api;

public interface IRecipeApiService
{
    Task<List<RecipeToGet>> GetRecipes();
    Task<DetailedRecipeToGet> GetRecipe(Guid id);
    Task<Guid> AddRecipe(RecipeToAdd recipeToAdd);
}
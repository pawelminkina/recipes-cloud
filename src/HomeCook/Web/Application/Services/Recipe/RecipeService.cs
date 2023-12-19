using Application.Models.Recipes;
using Application.Services.Files;
using Application.Services.Api;

namespace Application.Services.Recipe;

public class RecipeService : IRecipeService
{
    private readonly IPhotoService _photoService;
    private readonly IRecipeApiService _recipeApiService;

    public RecipeService(IPhotoService photoService, IRecipeApiService recipeApiService)
    {
        _photoService = photoService;
        _recipeApiService = recipeApiService;
    }

    public async Task<List<RecipeDto>> GetAllRecipes()
    {
        var response = await _recipeApiService.GetRecipes();
        var recipes = await Task.WhenAll(response!.Select(AssignPhotoToRecipe));

        return recipes.ToList();
    }

    public async Task<RecipeDetailsDto> GetRecipeDetails(Guid id)
    {
        var response = await _recipeApiService.GetRecipe(id);
        var recipe = await AssignPhotoDetailsToRecipe(response!);

        return recipe;
    }

    public async Task<Guid> AddRecipe(RecipeToAddDto recipeToAddDto)
    {
        var addedPhotoId = await _photoService.AddPhoto(recipeToAddDto.MainPhoto, recipeToAddDto.FileExtension);

        var recipeToAdd = new RecipeToAdd()
        {
            AuthorEmail = recipeToAddDto.AuthorEmail,
            Title = recipeToAddDto.Title,
            Content = recipeToAddDto.Content,
            MainPhotoId = addedPhotoId
        };

        var res = await _recipeApiService.AddRecipe(recipeToAdd);
        return res;
    }

    private async Task<RecipeDto> AssignPhotoToRecipe(RecipeToGet recipeDto)
    {
        var photo = await _photoService.GetPhoto(recipeDto.MainPhotoId);
        return new RecipeDto()
        {
            Id = recipeDto.Id,
            MainPhotoUrl = photo.PhotoUrl,
            AuthorEmail = recipeDto.AuthorEmail,
            Title = recipeDto.Title
        };
    }

    private async Task<RecipeDetailsDto> AssignPhotoDetailsToRecipe(DetailedRecipeToGet recipeDto)
    {
        var photo = await _photoService.GetPhoto(recipeDto.MainPhotoId);
        return new RecipeDetailsDto()
        {
            Id = recipeDto.Id,
            MainPhotoUrl = photo.PhotoUrl,
            AuthorEmail = recipeDto.AuthorEmail,
            Title = recipeDto.Title,
            Content = recipeDto.Content
        };
    }
}
using Application.Config;
using Application.Models.Recipes;
using Application.Services.Files;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Application.Services.Recipe;

public class RecipeService : IRecipeService
{
    private readonly IPhotoService _photoService;
    private readonly IOptions<ServicesConfig> _serviceOptions;
    private readonly HttpClient _httpClient;

    public RecipeService(IPhotoService photoService, IOptions<ServicesConfig> serviceOptions, IHttpClientFactory httpClientFactory)
    {
        _photoService = photoService;
        _serviceOptions = serviceOptions;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<List<RecipeDto>> GetAllRecipes()
    {
        var getAllRecipesUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/Recipe";
        var response = await _httpClient.GetFromJsonAsync<List<RecipeToGet>>(getAllRecipesUrl);

        var recipes = await Task.WhenAll(response!.Select(AssignPhotoToRecipe));

        return recipes.ToList();
    }

    public async Task<RecipeDetailsDto> GetRecipeDetails(Guid id)
    {
        var getRecipeDetailsUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/Recipe/{id}";
        var response = await _httpClient.GetFromJsonAsync<DetailedRecipeToGet>(getRecipeDetailsUrl);

        var recipe = await AssignPhotoDetailsToRecipe(response!);

        return recipe;
    }

    public async Task<Guid> AddRecipe(RecipeToAddDto recipeToAddDto)
    {
        var addedPhotoId = await _photoService.AddPhoto(recipeToAddDto.MainPhoto, recipeToAddDto.FileExtension);

        var addRecipeUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/Recipe";
        var response = await _httpClient.PostAsync(addRecipeUrl, new StringContent(JsonSerializer.Serialize(new RecipeToAdd()
        {
            AuthorEmail = recipeToAddDto.AuthorEmail,
            Title = recipeToAddDto.Title,
            Content = recipeToAddDto.Content,
            MainPhotoId = addedPhotoId
        }), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(stringContent))
        {
            throw new InvalidOperationException("Adding photo failed and no id was returned");
        }

        return JsonSerializer.Deserialize<Guid>(stringContent);
    }

    private async Task<RecipeDto> AssignPhotoToRecipe(RecipeToGet recipeDto)
    {
        var photo = await _photoService.GetPhoto(recipeDto.MainPhotoId);
        return new RecipeDto()
        {
            Id = recipeDto.Id,
            MainPhoto = photo.Photo,
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
            MainPhoto = photo.Photo,
            AuthorEmail = recipeDto.AuthorEmail,
            Title = recipeDto.Title,
            Content = recipeDto.Content
        };
    }
}
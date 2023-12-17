using Application.Models.Recipes;
using Application.Services.Api;
using Application.Services.Recipe;
using Infrastructure.Config;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

namespace Infrastructure.Api.Recipe;

public class HttpRecipeApiService : IRecipeApiService
{
    private readonly IOptions<ServicesConfig> _serviceOptions;
    private readonly HttpClient _httpClient;

    public HttpRecipeApiService(IOptions<ServicesConfig> serviceOptions, IHttpClientFactory httpClientFactory)
    {
        _serviceOptions = serviceOptions;
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<DetailedRecipeToGet> GetRecipe(Guid id)
    {
        var getRecipeDetailsUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/api/Recipe/{id}";
        var response = await _httpClient.GetFromJsonAsync<DetailedRecipeToGet>(getRecipeDetailsUrl);
        return response!;
    }

    public async Task<Guid> AddRecipe(RecipeToAdd recipeToAdd)
    {
        var addRecipeUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/api/Recipe";
        var response = await _httpClient.PostAsync(addRecipeUrl, new StringContent(JsonSerializer.Serialize(recipeToAdd), Encoding.UTF8, "application/json"));

        response.EnsureSuccessStatusCode();

        var stringContent = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(stringContent))
        {
            throw new InvalidOperationException("Adding photo failed and no id was returned");
        }

        return JsonSerializer.Deserialize<Guid>(stringContent);
    }

    public async Task<List<RecipeToGet>> GetRecipes()
    {
        var getAllRecipesUrl = $"{_serviceOptions.Value.RecipeServiceBaseUrl}/api/Recipe";
        var response = await _httpClient.GetFromJsonAsync<List<RecipeToGet>>(getAllRecipesUrl);
        return response!;
    }
}
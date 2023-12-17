using Application.Services.Files;
using Application.Services.Recipe;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IPhotoService, PhotoService>();
        serviceCollection.AddScoped<IRecipeService, RecipeService>();
    }
}
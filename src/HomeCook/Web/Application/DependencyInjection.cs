using Application.Config;
using Application.Services.Files;
using Application.Services.Recipe;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPhotoService, PhotoService>();
        serviceCollection.AddScoped<IRecipeService, RecipeService>();
        serviceCollection.AddOptions<ServicesConfig>("ServicesConfig");
    }
}
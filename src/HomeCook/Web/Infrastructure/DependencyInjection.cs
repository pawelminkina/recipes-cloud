using Application.Services.Api;
using Application.Services.Storage;
using Infrastructure.Api.Photo;
using Infrastructure.Api.Recipe;
using Infrastructure.Config;
using Infrastructure.Storage.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.Configure<ServicesConfig>(configuration.GetSection("ServicesConfig"));
        serviceCollection.AddScoped<IPhotoApiService, HttpPhotoApiService>();
        serviceCollection.AddScoped<IRecipeApiService, HttpRecipeApiService>();

        var environment = configuration.GetValue<string>("DeployedEnvironment");

        switch (environment)
        {
            case "Azure":
                AddAzureEnvironment(serviceCollection, configuration);
                break;
            default:
                throw new ArgumentException($"Unknown environment: {environment}");
        }
    }

    public static void AddAzureEnvironment(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddScoped<IPhotosStorageService, AzurePhotosStorageService>();
        serviceCollection.Configure<AzureStorageAccountConfig>(configuration.GetSection("AzureStorageAccount"));
    }
}
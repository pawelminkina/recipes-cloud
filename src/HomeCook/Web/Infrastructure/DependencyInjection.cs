using Application.Services.Storage;
using Infrastructure.Config;
using Infrastructure.Storage.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var environment = configuration.GetValue<string>("DeployedEnvironment");

        switch (environment)
        {
            case "Azure":
                AddAzureEnvironment(serviceCollection);
                break;
            default:
                throw new ArgumentException($"Unknown environment: {environment}");
        }
    }

    public static void AddAzureEnvironment(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPhotosStorageService, AzurePhotosStorageService>();
        serviceCollection.AddOptions<AzureStorageAccountConfig>("AzureStorageAccount");
    }
}
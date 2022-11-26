using Application.Common.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.POCO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<RecipeDbContext>();

        serviceCollection.AddScoped<IRecipeDbContext, RecipeDbContext>();

        serviceCollection.AddOptions<DatabaseOptions>().Bind(configuration.GetSection("DatabaseOptions"));
    }
}
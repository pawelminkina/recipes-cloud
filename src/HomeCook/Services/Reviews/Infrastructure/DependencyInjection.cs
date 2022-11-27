using Application.Common.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ReviewDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetValue<string>("ReviewDatabaseConnectionString"));
        });

        serviceCollection.AddScoped<IReviewDbContext, ReviewDbContext>();
    }
}
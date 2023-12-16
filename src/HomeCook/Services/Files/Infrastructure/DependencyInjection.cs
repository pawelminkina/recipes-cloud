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
        serviceCollection.AddDbContext<FilesDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetValue<string>("FilesDatabaseConnectionString"));
        });

        serviceCollection.AddScoped<IFilesDbContext, FilesDbContext>();
    }
}
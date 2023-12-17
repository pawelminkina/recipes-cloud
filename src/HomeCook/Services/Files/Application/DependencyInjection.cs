using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(DependencyInjection).Assembly);
    }
}
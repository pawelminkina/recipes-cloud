using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IRecipeDbContext
{
    DbSet<Recipe> Recipes { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}
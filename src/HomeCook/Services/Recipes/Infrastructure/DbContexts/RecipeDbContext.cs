using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class RecipeDbContext : DbContext
{
    DbSet<Recipe> Recipes { get; set; }
}
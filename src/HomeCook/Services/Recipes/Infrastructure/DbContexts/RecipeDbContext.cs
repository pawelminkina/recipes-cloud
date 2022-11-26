using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class RecipeDbContext : DbContext, IRecipeDbContext
{
    
    public RecipeDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Recipe> Recipes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasKey(s => s.Id);

        base.OnModelCreating(modelBuilder);
    }
}
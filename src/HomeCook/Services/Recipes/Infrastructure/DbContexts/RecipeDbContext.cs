using Application.Common.Interfaces;
using Domain;
using Infrastructure.POCO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.DbContexts;

public class RecipeDbContext : DbContext, IRecipeDbContext
{
    private readonly IOptions<DatabaseOptions>? _databaseOptions;
    
    public RecipeDbContext(DbContextOptions options, IOptions<DatabaseOptions> databaseOptions) : base(options)
    {
        _databaseOptions = databaseOptions;
    }

    public RecipeDbContext()
    {
        
    }

    public DbSet<Recipe> Recipes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //For test purpose
        if (_databaseOptions is null)
            return;

        optionsBuilder.UseSqlServer(_databaseOptions.Value.ConnectionString!);

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().HasKey(s => s.Id);

        base.OnModelCreating(modelBuilder);
    }
}
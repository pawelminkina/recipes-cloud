using Application.Common.Interfaces;
using Domain;
using Infrastructure.Utilities;
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

        modelBuilder.Entity<Recipe>().HasData(new List<Recipe>
        {
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 1", Content = Const.LoremIpsumForImage, AuthorEmail = "author1@example.com",
                MainPhotoId = Guid.Parse("13d9b14d-b06f-4a50-90c5-71435bdbe75e")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 2", Content = Const.LoremIpsumForImage, AuthorEmail = "author1@example.com",
                MainPhotoId = Guid.Parse("2c8dc7ca-2392-42c0-a525-fdaa992f8baa")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 3", Content = Const.LoremIpsumForImage, AuthorEmail = "author2@example.com",
                MainPhotoId = Guid.Parse("a1b2c3d4-e5f6-4768-abcd-1234567890ab")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 4", Content = Const.LoremIpsumForImage, AuthorEmail = "author2@example.com",
                MainPhotoId = Guid.Parse("a7b8c9da-ebfc-ae0f-abcd-1234567890f2")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 5", Content = Const.LoremIpsumForImage, AuthorEmail = "author3@example.com",
                MainPhotoId = Guid.Parse("b2c3d4e5-f6a7-5899-abcd-1234567890bc")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 6", Content = Const.LoremIpsumForImage, AuthorEmail = "author3@example.com",
                MainPhotoId = Guid.Parse("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 7", Content = Const.LoremIpsumForImage, AuthorEmail = "author4@example.com",
                MainPhotoId = Guid.Parse("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 8", Content = Const.LoremIpsumForImage, AuthorEmail = "author4@example.com",
                MainPhotoId = Guid.Parse("d4e5f6a7-b8c9-7bac-abcd-1234567890de")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 9", Content = Const.LoremIpsumForImage, AuthorEmail = "author5@example.com",
                MainPhotoId = Guid.Parse("e5f6a7b8-c9da-8cbd-abcd-1234567890ef")
            },
            new Recipe
            {
                Id = Guid.NewGuid(), Title = "Recipe 10", Content = Const.LoremIpsumForImage, AuthorEmail = "author5@example.com",
                MainPhotoId = Guid.Parse("f6a7b8c9-daeb-9dce-abcd-1234567890f1")
            }
        });

        base.OnModelCreating(modelBuilder);
    }
}
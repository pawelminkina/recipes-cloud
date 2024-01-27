using System.Collections.Generic;
using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class FilesDbContext : DbContext, IFilesDbContext
{
    public FilesDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Photo> Photos { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Photo>().HasKey(s => s.Id);
        modelBuilder.Entity<Photo>().HasData(new List<Photo>
        {
            new Photo {Id = Guid.Parse("a1b2c3d4-e5f6-4768-abcd-1234567890ab"), Path = "food-photo1.jpg"},
            new Photo {Id = Guid.Parse("b2c3d4e5-f6a7-5899-abcd-1234567890bc"), Path = "food-photo2.jpg"},
            new Photo {Id = Guid.Parse("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"), Path = "food-photo3.jpg"},
            new Photo {Id = Guid.Parse("d4e5f6a7-b8c9-7bac-abcd-1234567890de"), Path = "food-photo4.jpg"},
            new Photo {Id = Guid.Parse("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"), Path = "food-photo5.jpg"},
            new Photo {Id = Guid.Parse("f6a7b8c9-daeb-9dce-abcd-1234567890f1"), Path = "food-photo6.jpg"},
            new Photo {Id = Guid.Parse("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"), Path = "food-photo7.jpg"},
            new Photo {Id = Guid.Parse("13d9b14d-b06f-4a50-90c5-71435bdbe75e"), Path = "food-photo8.jpg"},
            new Photo {Id = Guid.Parse("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"), Path = "food-photo9.jpg"},
            new Photo {Id = Guid.Parse("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"), Path = "food-photo10.jpg"}
        });

        base.OnModelCreating(modelBuilder);
    }
}
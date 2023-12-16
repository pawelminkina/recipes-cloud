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
            new Photo {Id = Guid.Parse("a1b2c3d4-e5f6-4768-abcd-1234567890ab"), Path = "photo1.png"},
            new Photo {Id = Guid.Parse("b2c3d4e5-f6a7-5899-abcd-1234567890bc"), Path = "photo2.png"},
            new Photo {Id = Guid.Parse("c3d4e5f6-a7b8-6a9b-abcd-1234567890cd"), Path = "photo3.png"},
            new Photo {Id = Guid.Parse("d4e5f6a7-b8c9-7bac-abcd-1234567890de"), Path = "photo4.png"},
            new Photo {Id = Guid.Parse("e5f6a7b8-c9da-8cbd-abcd-1234567890ef"), Path = "photo5.png"},
            new Photo {Id = Guid.Parse("f6a7b8c9-daeb-9dce-abcd-1234567890f1"), Path = "photo6.png"},
            new Photo {Id = Guid.Parse("a7b8c9da-ebfc-ae0f-abcd-1234567890f2"), Path = "photo7.png"},
            new Photo {Id = Guid.Parse("13d9b14d-b06f-4a50-90c5-71435bdbe75e"), Path = "photo8.png"},
            new Photo {Id = Guid.Parse("c2f7e61e-6da0-4ccd-9f7e-2e167e24fb9f"), Path = "photo9.png"},
            new Photo {Id = Guid.Parse("2c8dc7ca-2392-42c0-a525-fdaa992f8baa"), Path = "photo10.png"}
        });

        base.OnModelCreating(modelBuilder);
    }
}
using Application.Common.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class ReviewDbContext : DbContext, IReviewDbContext
{
    public ReviewDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Review> Reviews { get; set; } = null!;
    public DbSet<Photo> Photos { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasKey(s => s.Id);
        
        modelBuilder.Entity<Photo>().HasKey(s => s.Id);

        modelBuilder.Entity<Review>().HasMany(s=>s.Photos).WithOne(s=>s.RelatedReview).IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}
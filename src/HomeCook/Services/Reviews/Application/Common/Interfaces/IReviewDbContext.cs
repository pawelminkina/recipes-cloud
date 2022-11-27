using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IReviewDbContext
{
    Task<int> SaveChangesAsync(CancellationToken ct);
    DbSet<Review> Reviews { get; }
    DbSet<Photo> Photos { get; }
}
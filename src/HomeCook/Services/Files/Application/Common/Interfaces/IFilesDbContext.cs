using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IFilesDbContext
{
    DbSet<Photo> Photos { get; }
    Task<int> SaveChangesAsync(CancellationToken ct);
}
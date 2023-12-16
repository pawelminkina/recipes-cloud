using Application.Common.Interfaces;
using MediatR;

namespace Application.Queries.GetPhoto;

public class GetPhotoQuery : IRequest<Photo?>
{
    public Guid PhotoId { get; }

    public GetPhotoQuery(Guid photoId)
    {
        PhotoId = photoId;
    }
}

public class GetPhotoQueryHandler : IRequestHandler<GetPhotoQuery, Photo?>
{
    private readonly IFilesDbContext _dbContext;

    public GetPhotoQueryHandler(IFilesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Photo?> Handle(GetPhotoQuery request, CancellationToken cancellationToken)
    {
        var photo = await _dbContext.Photos.FindAsync(request.PhotoId, cancellationToken);

        return photo == null ? null : Photo.CreateFromDomain(photo);
    }
}
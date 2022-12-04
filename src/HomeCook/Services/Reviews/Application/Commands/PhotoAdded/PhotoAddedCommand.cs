using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.PhotoAdded;

public class PhotoAddedCommand : IRequest
{
    public string PathToPhoto { get; }

    public PhotoAddedCommand(string pathToPhoto)
    {
        PathToPhoto = pathToPhoto;
    }
}

public class PhotoAddedCommandHandler : IRequestHandler<PhotoAddedCommand>
{
    private readonly IReviewDbContext _dbContext;

    public PhotoAddedCommandHandler(IReviewDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Unit> Handle(PhotoAddedCommand request, CancellationToken cancellationToken)
    {
        var photoToAdd = new Photo()
        {
            Path = request.PathToPhoto
        };
        _dbContext.Photos.Add(photoToAdd);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
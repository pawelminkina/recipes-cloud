using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.AddPhoto;

public class AddPhotoCommand : IRequest<Guid>
{
    public PhotoToAdd PhotoToAdd { get; }

    public AddPhotoCommand(PhotoToAdd photoToAdd)
    {
        PhotoToAdd = photoToAdd;
    }
}

public class AddPhotoCommandHandler : IRequestHandler<AddPhotoCommand, Guid>
{
    private readonly IReviewDbContext _dbContext;

    public AddPhotoCommandHandler(IReviewDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(AddPhotoCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.PhotoToAdd.Path))
            throw new ArgumentNullException(nameof(request.PhotoToAdd));

        var photoToAdd = new Photo()
        {
            Path = request.PhotoToAdd.Path
        };

        _dbContext.Photos.Add(photoToAdd);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return photoToAdd.Id;
    }
}
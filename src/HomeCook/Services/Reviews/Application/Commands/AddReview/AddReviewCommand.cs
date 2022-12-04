using Application.Common.Interfaces;
using Domain;
using MediatR;
using System.Linq;

namespace Application.Commands.AddReview;

public class AddReviewCommand : IRequest<Guid>
{
    public ReviewToAdd ReviewToAdd { get; }

    public AddReviewCommand(ReviewToAdd reviewToAdd)
    {
        ReviewToAdd = reviewToAdd;
    }
}

public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Guid>
{
    private readonly IReviewDbContext _dbContext;

    public AddReviewCommandHandler(IReviewDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Guid> Handle(AddReviewCommand request, CancellationToken cancellationToken)
    {
        if (request.ReviewToAdd == null)
            throw new ArgumentNullException(nameof(request.ReviewToAdd));

        await WaitUntilPhotosAreUploaded(request.ReviewToAdd.PhotoPaths.ToList());

        var relatedPhotos = _dbContext.Photos.Where(s => request.ReviewToAdd.PhotoPaths.Any(g => s.Path == g)).ToList();

        var reviewToAdd = new Review()
        {
            Content = request.ReviewToAdd.Content,
            IdOfRelatedRecipe = request.ReviewToAdd.IdOfRelatedRecipe,
            Title = request.ReviewToAdd.Title,
            Photos = relatedPhotos
        };

        _dbContext.Reviews.Add(reviewToAdd);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return reviewToAdd.Id;
    }

    //TODO this should be configurable from settings
    private async Task WaitUntilPhotosAreUploaded(List<string> photoPaths)
    {
        var max = 10;
        var lastCount = 0;
        for (var i = 0; i < max; i++)
        {
            var relatedPhotosCount = _dbContext.Photos.Count(s => photoPaths.Any(g => s.Path == g));
            
            if (relatedPhotosCount > photoPaths.Count)
                if (lastCount < relatedPhotosCount)
                    max += 3;
                else
                    await Task.Delay(5000);
            else
                break;

            lastCount = relatedPhotosCount;
        }
    }
}
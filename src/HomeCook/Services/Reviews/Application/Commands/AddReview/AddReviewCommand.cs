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

        var relatedPhotos = _dbContext.Photos.Where(s => request.ReviewToAdd.PhotoIds.Any(g => s.Id == g)).ToList();
        
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
}
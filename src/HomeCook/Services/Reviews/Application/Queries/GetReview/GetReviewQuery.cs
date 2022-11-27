using Application.Common.Interfaces;
using MediatR;

namespace Application.Queries.GetReview;

public class GetReviewQuery : IRequest<Review?>
{
    public Guid ReviewId { get; }

    public GetReviewQuery(Guid reviewId)
    {
        ReviewId = reviewId;
    }
}

public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, Review?>
{
    private readonly IReviewDbContext _dbContext;

    public GetReviewQueryHandler(IReviewDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Review?> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var review = await _dbContext.Reviews.FindAsync(request.ReviewId, cancellationToken);

        return review == null ? null : Review.CreateFromDomain(review);
    }
}
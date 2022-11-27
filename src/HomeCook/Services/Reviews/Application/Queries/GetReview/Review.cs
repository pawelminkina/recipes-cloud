using Application.Queries.GetPhoto;

namespace Application.Queries.GetReview;

public record Review
{
    public Guid Id { get; set; }
    public Guid IdOfRelatedRecipe { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime TimeCreatedUtc { get; set; }
    public IEnumerable<Photo> Photos { get; set; }

    public static Review CreateFromDomain(Domain.Review review) => new()
    {
        Content = review.Content,
        Id = review.Id,
        Title = review.Title,
        IdOfRelatedRecipe = review.IdOfRelatedRecipe,
        TimeCreatedUtc = review.TimeCreatedUtc,
        Photos = review.Photos.Select(Photo.CreateFromDomain)
    };
}
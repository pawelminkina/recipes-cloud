namespace Application.Commands.AddReview;

public class ReviewToAdd
{
    public Guid IdOfRelatedRecipe { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IEnumerable<string> PhotoPaths { get; set; }
}
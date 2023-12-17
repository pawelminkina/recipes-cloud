namespace Application.Models.Storage;

public class RecipePhotoDto
{
    public Stream Photo { get; set; } = Stream.Null;
    public Guid Id { get; set; }
}
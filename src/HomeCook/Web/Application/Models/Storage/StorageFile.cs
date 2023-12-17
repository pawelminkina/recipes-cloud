namespace Application.Models.Storage;

public record StorageFile
{
    public string Path { get; set; } = string.Empty;
    public Stream Content { get; set; } = Stream.Null;
}
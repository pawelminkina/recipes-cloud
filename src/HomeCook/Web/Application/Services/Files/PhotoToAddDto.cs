namespace Application.Services.Files;

public record PhotoToAddDto
{
    public string Path { get; set; } = string.Empty;
}
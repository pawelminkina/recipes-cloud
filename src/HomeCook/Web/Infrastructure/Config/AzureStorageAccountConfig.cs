namespace Infrastructure.Config;

public record AzureStorageAccountConfig
{
    public string ConnectionString { get; set; } = string.Empty;
    public string PhotosContainerName { get; set; } = string.Empty;
}
namespace Infrastructure.Config;

public record ServicesConfig
{
    public string FileServiceBaseUrl { get; set; } = string.Empty;
    //public string FileServiceFunctionKey { get; set; } = string.Empty;
    public string RecipeServiceBaseUrl { get; set; } = string.Empty;
   // public string RecipeServiceFunctionKey { get; set; } = string.Empty;
}
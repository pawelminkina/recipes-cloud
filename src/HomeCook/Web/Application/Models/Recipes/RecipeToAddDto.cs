using Application.Utilities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Recipes;

public record RecipeToAddDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Author email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string AuthorEmail { get; set; }
    public Stream MainPhoto { get; set; }
    public string FileExtension { get; set; }
}
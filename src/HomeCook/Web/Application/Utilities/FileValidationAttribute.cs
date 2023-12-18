using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Application.Utilities;

public class FileValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file == null)
        {
            return new ValidationResult("A file is required");
        }

        var allowedExtensions = new[] { ".png", ".jpeg", ".jpg", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!allowedExtensions.Contains(fileExtension))
        {
            return new ValidationResult("Invalid file type. Allowed types: png, jpeg, gif");
        }

        return ValidationResult.Success;
    }
}
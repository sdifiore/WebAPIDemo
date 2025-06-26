using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models.Validations
{
    public class ShirtEnsureCorrectSizingAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Shirt? shirt = validationContext.ObjectInstance as Shirt;

            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && (shirt.Size < 8))
                    return new ValidationResult("For men's shirt the Size must be greater or equal than 8.");
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && (shirt.Size < 6))
                    return new ValidationResult("For women's shirt the Size must be greater or equal than 8.");
            }

            return ValidationResult.Success;
        }

        private string GetDebuggerDisplay()
        {
            return ToString() ?? string.Empty; // Fixes CS8603 by ensuring a non-null return value
        }
    }
}
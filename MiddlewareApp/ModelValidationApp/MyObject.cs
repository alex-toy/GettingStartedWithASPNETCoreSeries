using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationApp
{
    public class MyObject : IValidatableObject
    {
        [Required]
        [CustomName("R")]
        public string Name { get; set; }

        [Required]
        [Range(18, int.MaxValue)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Phone) && string.IsNullOrEmpty(Email))
            {
                string errorMessage = "Either Phone or Validation must be specified";
                yield return new ValidationResult(errorMessage, new[] {nameof(Phone), nameof(Email)});
            }
        }
    }
}

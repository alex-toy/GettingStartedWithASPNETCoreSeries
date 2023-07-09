using System.ComponentModel.DataAnnotations;

namespace ModelValidationApp
{
    public class CustomNameAttribute : ValidationAttribute
    {
        private readonly string startsWith;

        public CustomNameAttribute(string startsWith)
        {
            this.startsWith = startsWith;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is string valueString)) return new ValidationResult($"{validationContext.MemberName} is not a string");

            if (!valueString.StartsWith(startsWith))
            {
                string error = $"{validationContext.MemberName} does not start with {startsWith}";
                return new ValidationResult(error);  
            }
            
            return ValidationResult.Success;
        }
    }
}

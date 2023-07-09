using System.ComponentModel.DataAnnotations;

namespace ModelValidationApp
{
    public class MyData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18, int.MaxValue)]
        public int Age { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string? Phone { get; set; }
    }
}

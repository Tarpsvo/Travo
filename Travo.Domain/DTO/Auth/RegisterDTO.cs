using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email address was not valid.")]
        public string Email { get; set; }
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string DisplayName { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Travo.ViewModels.Auth
{
    public class RegisterVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
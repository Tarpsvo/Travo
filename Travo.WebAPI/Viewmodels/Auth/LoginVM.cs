using System.ComponentModel.DataAnnotations;

namespace Travo.ViewModels.Auth
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
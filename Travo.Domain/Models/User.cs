using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    class User
    {
        public int Id { get; set; }
        public long Created { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string Username { get; set; }
        [StringLength(254, MinimumLength = 1)]
        public string Email { get; set; }
        [StringLength(128, MinimumLength = 1)]
        public string PasswordHash { get; set; }
    }
}

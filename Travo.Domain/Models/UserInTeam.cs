using System.ComponentModel.DataAnnotations;
using Travo.Domain.Enums;

namespace Travo.Domain.Models
{
    class UserInTeam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public long Created { get; set; }
        public UserRoleInTeam Role { get; set; }
    }
}

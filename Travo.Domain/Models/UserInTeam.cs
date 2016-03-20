using System;
using Travo.Domain.Enums;

namespace Travo.Domain.Models
{
    public class UserInTeam
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public DateTime Created { get; set; }
        public UserRoleInTeam Role { get; set; }

        public UserInTeam()
        {
            Created = DateTime.UtcNow;
        }
    }
}

using System;

namespace Travo.Domain.Models
{
    public class BoardInTeam
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        public DateTime Created { get; set; }

        public BoardInTeam()
        {
            Created = DateTime.UtcNow;
        }
    }
}

namespace Travo.Domain.Models
{
    class BoardInTeam
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        public long Created { get; set; }
    }
}

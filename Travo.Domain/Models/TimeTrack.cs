namespace Travo.Domain.Models
{
    class TimeTrack
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
    }
}

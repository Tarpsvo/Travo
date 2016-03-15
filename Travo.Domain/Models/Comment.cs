using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    class Comment
    {
        public int Id { get; set; }
        public int ByUserId { get; set; }
        public virtual User ByUser { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public long Created { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string Text { get; set; }
    }
}

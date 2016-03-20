using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string ByUserId { get; set; }
        public virtual User ByUser { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public DateTime Created { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string Text { get; set; }

        public Comment()
        {
            Created = DateTime.UtcNow;
        }
    }
}

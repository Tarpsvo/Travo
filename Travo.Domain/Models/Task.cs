using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public DateTime Created { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string Description { get; set; }

        public Task()
        {
            Created = DateTime.UtcNow;
        }
    }
}

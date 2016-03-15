using System.ComponentModel.DataAnnotations;
using Travo.Domain.Enums;

namespace Travo.Domain.Models
{
    class TaskActivity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public TaskActivityType Type { get; set; }
        public long Time { get; set; }
        public int ByUserId { get; set; }
        public virtual User ByUser { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string NewValue { get; set; }
    }
}

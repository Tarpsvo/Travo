using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")]
        public string Color { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByUserId { get; set; }
        public int PositionInBoard { get; set; }

        public virtual Board Board { get; set; }
        public virtual User CreatedByUser { get; set; }

        public Tag()
        {
            Created = DateTime.UtcNow;
        }
    }
}

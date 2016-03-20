using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public DateTime Created { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }

        public Board()
        {
            Created = DateTime.UtcNow;
        }
    }
}

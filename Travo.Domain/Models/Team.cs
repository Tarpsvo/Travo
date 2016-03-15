﻿using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    class Team
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength =1)]
        public string Name { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string Description { get; set; }
        public long Created { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
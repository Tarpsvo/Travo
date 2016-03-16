﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength =1)]
        public string Name { get; set; }
        [StringLength(3000, MinimumLength = 1)]
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }

        public Team()
        {
            Created = DateTime.UtcNow;
        }
    }
}
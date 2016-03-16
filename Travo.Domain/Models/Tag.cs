﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Travo.Domain.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int BoardId { get; set; }
        public virtual Board Board { get; set; }
        [StringLength(30, MinimumLength = 1)]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public int CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
        public int PositionInBoard { get; set; }

        public Tag()
        {
            Created = DateTime.UtcNow;
        }
    }
}
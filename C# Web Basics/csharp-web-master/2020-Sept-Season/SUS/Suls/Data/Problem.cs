﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Suls.Data
{
    public class Problem
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Range(50, 300)]
        public int Points { get; set; }
    }
}

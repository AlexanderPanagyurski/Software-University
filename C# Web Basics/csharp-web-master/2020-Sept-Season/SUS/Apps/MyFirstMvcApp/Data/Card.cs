﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BattleCards.Data
{
    public class Card
    {
        public Card()
        {
            this.Users = new HashSet<UserCard>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Keyword { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }

        [Required]
        [MaxLength(byte.MaxValue)]
        public string Description { get; set; }

        public string UniverseLogoUrl { get; set; }

        [MaxLength(40)]
        public string UniverseName { get; set; }

        public virtual ICollection<UserCard> Users { get; set; }
    }
}

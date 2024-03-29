﻿using CarStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class State
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(AttributesConstraints.StateMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }
       
        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
        
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}

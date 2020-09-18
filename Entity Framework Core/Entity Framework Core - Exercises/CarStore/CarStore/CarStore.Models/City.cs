using CarStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class City
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(AttributesConstraints.CityMaxLength)]
        public string Name { get; set; }

        [ForeignKey(nameof(State))]
        public string StatedId { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class Country
    {
        public Country()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }


        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();

        public virtual ICollection<State> States { get; set; } = new HashSet<State>();
    }
}

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
        public string Id { get; set; }

        [ForeignKey(nameof(State))]
        public string StatedId { get; set; }
        public virtual State State { get; set; }
    }
}

using CarStore.Common;
using CarStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarStore.Models
{
    public class Engine
    {
        public Engine()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Range(AttributesConstraints.HorsePowerMinValue,AttributesConstraints.HorsePowerMaxValue)]
        public short HorsePower { get; set; }

        [Range(AttributesConstraints.EngineDisplacementMinValue,AttributesConstraints.EngineDisplacementMaxValue)]
        public double EngineDisplacement { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        public EuroEmissionType? EuroEmissionType { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}

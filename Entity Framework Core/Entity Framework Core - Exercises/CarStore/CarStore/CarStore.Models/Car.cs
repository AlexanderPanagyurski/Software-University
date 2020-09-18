using CarStore.Common;
using CarStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CarStore.Models
{
    public class Car
    {

        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(AttributesConstraints.MakeMaxLength)]
        public string Make { get; set; }

        [Required]
        [MaxLength(AttributesConstraints.ModelMaxLength)]
        public string Model { get; set; }

        [MaxLength(AttributesConstraints.CarDescriptionMaxLength)]
        public string Description { get; set; }

        [Range(typeof(decimal), AttributesConstraints.DecimalMinValue, AttributesConstraints.DecimalMaxValue)]
        public decimal? Price { get; set; }

        public double? FuelConsumption { get; set; }

        [Range(AttributesConstraints.MileageMinLength, AttributesConstraints.MileageMaxLength)]
        public double? Mileage { get; set; }

        [Required]
        public BodyType BodyType { get; set; }

        public PreviousOwnersType? PreviousOwnersType { get; set; }
        public DateTime? Registration { get; set; }

        [Required]
        public GearType GearType { get; set; }

        [ForeignKey(nameof(City))]
        public string CityId { get; set; }
        public virtual City  City{ get; set; }

        [ForeignKey(nameof(State))]
        public string StateId { get; set; }
        public virtual State State { get; set; }

        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }

        [ForeignKey(nameof(Engine))]
        public string EngineId { get; set; }
        public virtual Engine Engine { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<CarImage> CarImages { get; set; } = new HashSet<CarImage>();

        public virtual ICollection<CarComment> CarComments { get; set; } = new HashSet<CarComment>();
    }
}

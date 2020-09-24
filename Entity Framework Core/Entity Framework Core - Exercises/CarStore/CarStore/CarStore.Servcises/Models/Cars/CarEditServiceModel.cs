using CarStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarStore.Services.Models.Cars
{
    public class CarEditServiceModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public double? FuelConsumption { get; set; }

        public double? Mileage { get; set; }

        [Required]
        public BodyType BodyType { get; set; }

        public PreviousOwnersType? PreviousOwnersType { get; set; }

        public DateTime? Registration { get; set; }

        [Required]
        public GearType GearType { get; set; }

        public string CityId { get; set; }

        public string StateId { get; set; }

        public string CountryId { get; set; }

        public string EngineId { get; set; }

        public string UserId { get; set; }

        //[DataType(DataType.Upload)]
        //public ICollection<IFormFile> Images { get; set; }
    }
}

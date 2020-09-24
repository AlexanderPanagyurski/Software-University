using CarStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.Cars
{
    public class CarViewServiceModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
        public int Views { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? EditedOn { get; set; }

        public bool IsArchived { get; set; }

        public DateTime? ArchivedOn { get; set; }


        public bool IsReported { get; set; }

        public DateTime? ReportedOn { get; set; }

        public bool IsBanned { get; set; }

        public DateTime? BannedOn { get; set; }

        public bool IsPromoted { get; set; }

        public DateTime? PromotedOn { get; set; }

        public DateTime? PromotedUntil { get; set; }

        public double? FuelConsumption { get; set; }

        public double? Mileage { get; set; }

        public BodyType BodyType { get; set; }

        public PreviousOwnersType? PreviousOwnersType { get; set; }
        public DateTime? Registration { get; set; }

        public GearType GearType { get; set; }

        public string CityId { get; set; }

        public string StateId { get; set; }
 
        public string CountryId { get; set; }

        public string EngineId { get; set; }

        public string UserId { get; set; }
    }
}

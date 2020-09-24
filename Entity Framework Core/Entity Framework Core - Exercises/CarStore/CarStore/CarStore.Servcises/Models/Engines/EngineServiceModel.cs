using CarStore.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Services.Models.Engines
{
    class EngineServiceModel
    {
        public string Id { get; set; }

        public short HorsePower { get; set; }

        public double EngineDisplacement { get; set; }

        public FuelType FuelType { get; set; }

        public EuroEmissionType? EuroEmissionType { get; set; }
    }
}

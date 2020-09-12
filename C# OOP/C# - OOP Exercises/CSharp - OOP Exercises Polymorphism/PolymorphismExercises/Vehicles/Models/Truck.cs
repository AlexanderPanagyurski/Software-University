using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double DEF_FUEL_CONSUMPTIOM = 1.6;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + DEF_FUEL_CONSUMPTIOM, tankCapacity)
        {
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel * 0.95 <= 0)
            {
                throw new FuelQuantityException();
            }
            if (amountOfFuel * 0.95 > TankCapacity)
            {
                throw new NotEnoughFuelCapacityException($"Cannot fit {amountOfFuel} fuel in the tank");
            }
            this.FuelQuantity += amountOfFuel * 0.95;
        }
    }
}

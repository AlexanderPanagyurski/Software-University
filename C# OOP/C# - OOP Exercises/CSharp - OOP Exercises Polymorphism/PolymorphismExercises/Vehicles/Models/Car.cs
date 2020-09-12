using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double DEF_FUEL_CONSUMPTIOM = 0.9;
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm + DEF_FUEL_CONSUMPTIOM, tankCapacity)
        {
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel <= 0)
            {
                throw new FuelQuantityException();
            }
            if (amountOfFuel > TankCapacity)
            {
                throw new NotEnoughFuelCapacityException($"Cannot fit {amountOfFuel} fuel in the tank");
            }
            this.FuelQuantity += amountOfFuel;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_WITH_PEOPLE = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            this.FuelConsumptionPerKm += FUEL_CONSUMPTION_WITH_PEOPLE;
            return base.Drive(distance);
        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
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

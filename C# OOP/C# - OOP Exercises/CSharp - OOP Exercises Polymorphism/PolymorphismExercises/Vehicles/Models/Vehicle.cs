using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new FuelQuantityException();
                }
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumptionPerKm { get; protected set; }
        public double TankCapacity { get; private set; }

        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            this.TankCapacity = (fuelQuantity > tankCapacity) ? 0 : tankCapacity;
        }

        public virtual string Drive(double distance)
        {
            var cantravel = (this.FuelQuantity - distance * this.FuelConsumptionPerKm) > 0;

            if (!cantravel)
            {
                throw new NotEnoughFuelException($"{this.GetType().Name} needs refueling");

            }
            this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public abstract void Refuel(double amountOfFuel);

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = DefaultFuelConsumption;
        }

        public virtual double FuelConsumption { get;protected set; }

        public double Fuel { get;protected set; }

        public int HorsePower { get;protected set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }

    }
}

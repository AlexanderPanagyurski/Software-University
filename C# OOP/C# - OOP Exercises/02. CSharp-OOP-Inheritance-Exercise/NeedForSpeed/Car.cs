using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const int DefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
        }
    }
}

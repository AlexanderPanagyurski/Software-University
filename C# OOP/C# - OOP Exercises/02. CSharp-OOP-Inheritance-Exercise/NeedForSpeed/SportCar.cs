using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const int DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = DefaultFuelConsumption;
        }
        
    }
}

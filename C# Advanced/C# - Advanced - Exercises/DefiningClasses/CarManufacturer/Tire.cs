using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Tire
    {
        private int year;
        private double preassure;

        public int Year { get; set; }
        public double Preassure { get; set; }

        public Tire(int year, double preassure)
        {
            Year = year;
            Preassure = preassure;
        }
    }
}

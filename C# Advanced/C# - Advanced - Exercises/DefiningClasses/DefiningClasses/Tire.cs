using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public double TireOnePreassure { get; set; }
        public int TireOneAge { get; set; }
        public double TireTwoPreassure { get; set; }
        public int TireTwoAge { get; set; }
        public double TireThreePreassure { get; set; }
        public int TireThreeAge { get; set; }
        public double TireFourPreassure { get; set; }
        public int TireFourAge { get; set; }

        public Tire(double tireOnePreassure, int tireOneAge, double tireTwoPreassure, int tireTwoAge,
            double tireThreePreassure, int tireThreeAge, double tireFourPreassure, int tireFourAge)
        {
            TireOnePreassure = tireOnePreassure;
            TireOneAge = tireOneAge;
            TireTwoPreassure = tireTwoPreassure;
            TireTwoAge = tireTwoAge;
            TireThreePreassure = tireThreePreassure;
            TireThreeAge = tireThreeAge;
            TireFourPreassure = tireFourPreassure;
            TireFourAge = tireFourAge;
        }
    }
}

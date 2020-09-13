using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire tire;

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public Car()
        {

            Make = "Alfa Romeo";
            Model = "147";
            Year = 2003;
            FuelConsumption = 10;
            FuelQuantity = 200;
        }
        public Car(string make, string model, int year)
            : this()
        {
            Model = model;
            Make = make;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,
            Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }

        public void Drive(double distance)
        {
            bool hasFuel = FuelQuantity - distance * FuelConsumption > 0;
            if (hasFuel)
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string CarInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Make: {Make}\n");
            builder.Append($"Model: {Model}\n");
            builder.Append($"Year: {Year}\n");
            builder.Append($"Fuel: {FuelConsumption:f2}L");

            return builder.ToString();
        }
    }
}

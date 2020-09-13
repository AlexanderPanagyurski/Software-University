using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var cars = new Dictionary<string, List<Car>>();
            cars.Add("fragile", new List<Car>());
            cars.Add("flamable", new List<Car>());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
                Tire tire1 = new Tire(double.Parse(input[5]), int.Parse(input[6]));
                Tire tire2 = new Tire(double.Parse(input[7]), int.Parse(input[8]));
                Tire tire3 = new Tire(double.Parse(input[9]), int.Parse(input[10]));
                Tire tire4 = new Tire(double.Parse(input[11]), int.Parse(input[12]));
                Car car = new Car(input[0], engine, cargo);
                car.AddTiresInfo(tire1, tire2, tire3, tire4);

                if (car.Cargo.CargoType == "fragile")
                {
                    cars["fragile"].Add(car);
                }
                else if (car.Cargo.CargoType == "flamable")
                {
                    cars["flamable"].Add(car);
                }
            }
            string output = Console.ReadLine();
            if (output == "flamable")
            {
                foreach (var item in cars[output])
                {
                    if (item.Engine.EnginePower>250)
                    {
                        Console.WriteLine(item.Model);
                    } 
                }
            }
            else if(output=="fragile")
            {
                foreach (var item in cars[output])
                {
                    if (item.IsLessThan1())
                    {
                        Console.WriteLine(item.Model);
                    }
                }
            }

        }
    }
}

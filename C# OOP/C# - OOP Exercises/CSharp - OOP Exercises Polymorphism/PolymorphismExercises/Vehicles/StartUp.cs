using System;
using System.Collections.Generic;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            var carInfo = Console.ReadLine().Split(' ');
            var truckInfo = Console.ReadLine().Split(' ');
            var busInfo = Console.ReadLine().Split(' ');

            try
            {
                vehicles.Add(new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3])));
                vehicles.Add(new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(carInfo[3])));
                vehicles.Add(new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3])));
            }
            catch (FuelQuantityException fqe)
            {
                Console.WriteLine(fqe.Message);
            }
            catch (NotEnoughFuelCapacityException nefce)
            {
                Console.WriteLine(nefce.Message);
            }


            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var commandArgs = Console.ReadLine().Split(' ');

                if (commandArgs[0] == "Drive")
                {
                    if (commandArgs[1] == "Car")
                    {
                        try
                        {
                            Console.WriteLine(vehicles[0].Drive(double.Parse(commandArgs[2])));

                        }
                        catch (NotEnoughFuelException nefe)
                        {
                            Console.WriteLine(nefe.Message);
                        }
                    }
                    else if (commandArgs[1] == "Truck")
                    {
                        try
                        {
                            Console.WriteLine(vehicles[1].Drive(double.Parse(commandArgs[2])));
                        }
                        catch (NotEnoughFuelException nefe)
                        {
                            Console.WriteLine(nefe.Message);
                        }
                    }
                    else if (commandArgs[1] == "Bus")
                    {
                        try
                        {
                            Console.WriteLine(((Bus)vehicles[2]).Drive(double.Parse(commandArgs[2])));
                        }
                        catch (NotEnoughFuelException nefe)
                        {
                            Console.WriteLine(nefe.Message);
                        }
                    }
                }
                else if (commandArgs[0] == "Refuel")
                {
                    try
                    {
                        if (commandArgs[1] == "Car")
                        {
                            vehicles[0].Refuel(double.Parse(commandArgs[2]));
                        }
                        else if (commandArgs[1] == "Truck")
                        {
                            vehicles[1].Refuel(double.Parse(commandArgs[2]));
                        }
                        else if (commandArgs[1] == "Bus")
                        {
                            vehicles[2].Refuel(double.Parse(commandArgs[2]));
                        }
                    }
                    catch (NotEnoughFuelCapacityException nefce)
                    {
                        Console.WriteLine(nefce.Message);
                    }
                    catch(FuelQuantityException fqe)
                    {
                        Console.WriteLine(fqe.Message);
                    }
                }
                else if (commandArgs[0] == "DriveEmpty")
                {
                    try
                    {
                        ((Bus)vehicles[2]).Drive(double.Parse(commandArgs[2]));

                    }
                    catch (NotEnoughFuelException nefe)
                    {
                        Console.WriteLine(nefe.Message);
                    }
                }
            }
            Console.WriteLine(vehicles[0]);
            Console.WriteLine(vehicles[1]);
            Console.WriteLine(vehicles[2]);
        }
    }
}

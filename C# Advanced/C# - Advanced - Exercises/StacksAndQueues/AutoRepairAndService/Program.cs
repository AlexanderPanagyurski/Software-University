using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRepairAndService
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seqVehicles = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> vehiclesQueue = new Queue<string>(seqVehicles);
            Stack<string> servedVehicles = new Stack<string>();
            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Service" && vehiclesQueue.Count>0)
                {
                    servedVehicles.Push(vehiclesQueue.Peek());
                    Console.WriteLine($"Vehicle {vehiclesQueue.Peek()} got served.");
                    vehiclesQueue.Dequeue();
                }
                else if (command.Contains("CarInfo"))
                {
                    string[] splitCommand = command.Split('-');
                    string modelName = splitCommand[1];
                    if (vehiclesQueue.Contains(modelName))
                    {
                        Console.WriteLine("Still waiting for service.");
                    }
                    else
                    {
                        Console.WriteLine("Served.");
                    }
                }
                else if (command == "History")
                {
                    Console.WriteLine(string.Join(", ",servedVehicles));
                }
                command = Console.ReadLine();
            }
            if (vehiclesQueue.Count>0)
            {
                Console.WriteLine($"Vehicles for service: {string.Join(", ", vehiclesQueue)}");
            }
            Console.WriteLine($"Served vehicles: {string.Join(", ",servedVehicles)}");
        }
    }
}

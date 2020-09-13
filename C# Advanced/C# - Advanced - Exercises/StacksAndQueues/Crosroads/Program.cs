using System;
using System.Collections.Generic;

namespace Crosroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenlightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            bool isSafe = true;
            string command = Console.ReadLine();

            while (command?.ToUpper() != "END")
            {
                if (command == "green")
                {
                    int time = greenlightDuration + freeWindowDuration;
                    while (time > freeWindowDuration && cars.Count > 0)
                    {
                        string currCar = cars.Dequeue();
                        if (currCar.Length > time)
                        {
                            int index = currCar.Length - time;
                            time -= currCar.Length;
                            isSafe = false;
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currCar} was hit at {currCar[index]}.");
                            return;
                        }
                        else
                        {
                            time -= currCar.Length;
                            counter++;
                        }
                    }
                }
                else
                {
                    string currCar = command;
                    cars.Enqueue(currCar);
                }
                command = Console.ReadLine();
            }
            if (isSafe)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }
        }
    }
}

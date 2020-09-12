using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());

            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < peopleNumber; i++)
            {
                var input = Console.ReadLine().Split(' ');
                if (input.Length == 3)
                {
                    buyers.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
                else if (input.Length == 4)
                {
                    buyers.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
            }

            string command = Console.ReadLine();

            int totalAmount = 0;

            while (command != "End")
            {
                var person = buyers.FirstOrDefault(p => p.Name == command);

                if (person != null)
                {
                    totalAmount += person.BuyFood();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(totalAmount);
        }
    }
}

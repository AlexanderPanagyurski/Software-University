using System;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (input.Length == 4)
            {
                double pricePerDay = double.Parse(input[0]);
                int daysCount = int.Parse(input[1]);
                string season = input[2];
                string discountType = input[3];

                double price = PriceCalculator.Calculate(pricePerDay, daysCount, season, discountType);
                Console.WriteLine($"{price:f2}");
            }
            else if (input.Length == 3)
            {
                double pricePerDay = double.Parse(input[0]);
                int daysCount = int.Parse(input[1]);
                string season = input[2];

                double price = PriceCalculator.Calculate(pricePerDay, daysCount, season);
                Console.WriteLine($"{price:f2}");
            }
           
        }
    }
}

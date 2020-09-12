using PizzaCalories.Models;
using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var pizzaInput = Console.ReadLine().Split(" ");
                var doughInput = Console.ReadLine().Split(" ");
                Dough dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));

                Pizza pizza = new Pizza(pizzaInput[1], dough);

                var command = Console.ReadLine();

                while (command != "END")
                {
                    var toppingInput = command.Split(" ");
                    Topping topping = new Topping(toppingInput[1], double.Parse(toppingInput[2]));

                    pizza.AddTopping(topping);

                    if (pizza.NumberOfToppings > 10)
                    {
                        throw new ArgumentException("Number of toppings should be in range [0..10].");
                    }

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}

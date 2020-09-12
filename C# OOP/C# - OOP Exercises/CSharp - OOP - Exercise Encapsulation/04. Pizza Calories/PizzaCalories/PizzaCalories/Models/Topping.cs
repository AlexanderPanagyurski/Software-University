using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            if (type.ToLower() != "meat" && type.ToLower() != "veggies" && type.ToLower() != "cheese" && type.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {type} on top of your pizza.");
            }
            this.type = type.ToLower();

            if (weight<1 || weight>50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
            this.weight = weight;
        }

        public double CaloriesPerGram { get => CalculateTotalCalories(); }

        private double CalculateTotalCalories()
        {
            var typeModifier = new Dictionary<string, double>();

            typeModifier.Add("meat", 1.2);
            typeModifier.Add("veggies", 0.8);
            typeModifier.Add("cheese", 1.1);
            typeModifier.Add("sauce",0.9);

            return (BaseCaloriesPerGram * weight) * typeModifier[type];
        }
    }
}

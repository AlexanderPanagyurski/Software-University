using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings=new List<Topping>();

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public int NumberOfToppings { get => toppings.Count; }

        public double TotalCalories { get => CalculatetotalCalories(); }

        private double CalculatetotalCalories()
        {
            var toppingsTotalCalories = toppings.Sum(t => t.CaloriesPerGram);

            return dough.CaloriesPerGram + toppingsTotalCalories;
        }

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories:f2} Calories.";
        }
    }
}

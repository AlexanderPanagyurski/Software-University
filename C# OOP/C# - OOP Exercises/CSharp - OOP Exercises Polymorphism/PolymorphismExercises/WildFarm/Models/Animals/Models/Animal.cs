using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;

namespace WildFarm.Models.Animals.Models
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; private set; }

        public void Feed(IFood food)
        {
            CheckFood(food);
            this.FoodEaten += food.Quantity;
            WeightGain();
        }

        private void WeightGain()
        {
            var weightGains = new Dictionary<string, double>();
            weightGains.Add("Hen", 0.35);
            weightGains.Add("Owl", 0.25);
            weightGains.Add("Mouse", 0.10);
            weightGains.Add("Cat", 0.30);
            weightGains.Add("Dog", 0.40);
            weightGains.Add("Tiger", 1.00);
            this.Weight += FoodEaten * weightGains[this.GetType().Name];
        }

        private void CheckFood(IFood food)
        {
            var foodsAndAnimals = new Dictionary<string, List<string>>();
            foodsAndAnimals.Add("Hen", new List<string>() { "Vegetable", "Fruit", "Meat", "Seeds" });
            foodsAndAnimals.Add("Mouse", new List<string>() { "Vegetable", "Fruit" });
            foodsAndAnimals.Add("Cat", new List<string>() { "Vegetable", "Meat" });
            foodsAndAnimals.Add("Tiger", new List<string>() { "Meat" });
            foodsAndAnimals.Add("Dog", new List<string>() { "Meat" });
            foodsAndAnimals.Add("Owl", new List<string>() { "Meat" });

            if (!foodsAndAnimals[this.GetType().Name].Contains(food.GetType().Name))
            {
                throw new InvalidFoodTypeException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} {Name} {Weight} ";
        }
    }
}

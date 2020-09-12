using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double DefaultDoughCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            if ((flourType.ToLower() != "white" && flourType.ToLower() != "wholegrain") || (bakingTechnique.ToLower() != "crispy" && bakingTechnique.ToLower() != "chewy" && bakingTechnique.ToLower() != "homemade"))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = flourType.ToLower();
            this.bakingTechnique = bakingTechnique.ToLower();

            if (weight < 1 || weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = weight;
        }

        public double CaloriesPerGram { get => CalculateTotalCalories(); }

        private double CalculateTotalCalories()
        {
            var flourTypeModifiers = new Dictionary<string, double>();
            var bakingTechniqueModifiers = new Dictionary<string, double>();

            flourTypeModifiers.Add("white", 1.5);
            flourTypeModifiers.Add("wholegrain", 1.0);

            bakingTechniqueModifiers.Add("crispy", 0.9);
            bakingTechniqueModifiers.Add("chewy", 1.1);
            bakingTechniqueModifiers.Add("homemade", 1.0);

            return (DefaultDoughCaloriesPerGram * weight) * flourTypeModifiers[flourType] * bakingTechniqueModifiers[bakingTechnique];
        }
    }
}

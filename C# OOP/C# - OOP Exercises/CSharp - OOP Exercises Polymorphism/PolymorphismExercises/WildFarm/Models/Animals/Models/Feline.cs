using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Models
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, int foodEaten, string livingRegion, string breed)
            : base(name, weight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.LivingRegion} {this.Breed}";
        }
    }
}

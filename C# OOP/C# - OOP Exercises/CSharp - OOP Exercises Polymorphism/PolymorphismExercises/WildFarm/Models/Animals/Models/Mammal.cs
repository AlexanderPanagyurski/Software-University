using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Models
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, int foodEaten,string livingRegion)
            : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + this.LivingRegion;
        }
    }
}

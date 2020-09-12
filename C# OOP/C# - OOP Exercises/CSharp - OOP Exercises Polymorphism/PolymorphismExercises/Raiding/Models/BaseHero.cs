using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public string Name { get; private set; }

        public int Power { get; private set; }

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public abstract string CastAbility();
    }
}

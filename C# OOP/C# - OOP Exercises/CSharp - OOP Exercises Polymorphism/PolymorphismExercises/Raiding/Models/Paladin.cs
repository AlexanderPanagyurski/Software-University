using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero, IPaladin
    {
        private const int DEF_POWER = 100;
        public Paladin(string name)
            : base(name, DEF_POWER)
        {
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}

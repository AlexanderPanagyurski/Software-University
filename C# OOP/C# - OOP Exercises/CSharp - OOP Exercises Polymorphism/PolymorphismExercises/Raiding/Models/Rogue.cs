using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero, IRogue
    {
        private const int DEF_POWER = 80;
        public Rogue(string name)
            : base(name, DEF_POWER)
        {
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {this.Power} damage";
        }
    }
}

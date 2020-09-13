using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;
        public string Name { get; private set; }
        public int Count
        {
            get
            {
                return gladiators.Count;
            }
        }

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public void Add(Gladiator gladiator)
        {
            if (!gladiators.Contains(gladiator))
            {
                gladiators.Add(gladiator);
            }
        }
        public void Remove(string name)
        {
            Gladiator gladiator = gladiators.FirstOrDefault(g => g.Name == name);
            gladiators.Remove(gladiator);
        }
        public Gladiator GetGladitorWithHighestStatPower()
        {
            return this.gladiators.OrderByDescending(x => x.GetStatPower()).FirstOrDefault();
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            return this.gladiators.OrderByDescending(x => x.GetWeaponPower()).FirstOrDefault();
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            return this.gladiators.OrderByDescending(x => x.GetTotalPower()).FirstOrDefault();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"[{Name}] - [{gladiators.Count}] gladiators are participating." + Environment.NewLine);
            return builder.ToString().TrimEnd();
        }
    }
}

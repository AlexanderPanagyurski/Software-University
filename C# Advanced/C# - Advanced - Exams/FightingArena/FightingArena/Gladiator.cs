using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public string Name { get; private set; }
        public Stat Stat { get; private set; }
        public Weapon Weapon { get; private set; }

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }

        public int GetTotalPower()
        {
            return Stat.PropertiesSum() + Weapon.PropertiesSum();
        }
        public int GetWeaponPower()
        {
            return Weapon.PropertiesSum();
        }
        public int GetStatPower()
        {
            return Stat.PropertiesSum();
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"[{Name}] - [{GetWeaponPower()}]" + Environment.NewLine);
            builder.Append($"  Weapon Power: [{Weapon.PropertiesSum()}]" + Environment.NewLine);
            builder.Append($"  Stat Power: [{Stat.PropertiesSum()}]" + Environment.NewLine);

            return builder.ToString().TrimEnd();
        }
    }
}

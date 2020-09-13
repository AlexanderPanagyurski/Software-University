﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Item
    {
        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public Item(int strength, int ability, int intelligence)
        {
            Strength = strength;
            Ability = ability;
            Intelligence = intelligence;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"Item:" + Environment.NewLine);
            builder.Append($"  * Strength: {Strength}" + Environment.NewLine);
            builder.Append($"  * Ability: {Ability}" + Environment.NewLine);
            builder.Append($"  * Intelligence: {Intelligence}" + Environment.NewLine);

            return builder.ToString();
        }
    }
}

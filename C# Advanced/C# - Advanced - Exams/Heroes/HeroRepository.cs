using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;

        public int Count => data.Count;

        public HeroRepository()
        {
            data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            if (!data.Contains(hero))
            {
                data.Add(hero);
            }
        }

        public void Remove(string name)
        {
            Hero hero = data.FirstOrDefault(h => h.Name == name);
            if (data.Contains(hero))
            {
                data.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data.OrderByDescending(h => h.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return data.OrderByDescending(h => h.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return data.OrderByDescending(h => h.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in data)
            {
                builder.Append(item.ToString());
            }
            return builder.ToString();
        }
    }
}

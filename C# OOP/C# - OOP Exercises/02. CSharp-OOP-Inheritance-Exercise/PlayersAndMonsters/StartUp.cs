using System;
using System.Collections.Generic;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            heroes.Add(new Hero("Vlado", 15));
            heroes.Add(new Elf("Delsaran Carbanise", 86));
            heroes.Add(new MuseElf("Arbelladon Eilmaris", 97));
            heroes.Add(new Wizard("Olin", 58));
            heroes.Add(new DarkWizard("Ivae", 68));
            heroes.Add(new SoulMaster("Ovys", 94));
            heroes.Add(new Knight("Tedric, el Repugnante", 59));
            heroes.Add(new DarkKnight("Lambard, le Conquérant", 75));
            heroes.Add(new BladeKnight("Bertran the Scar", 101));

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero);
            }
        }
    }
}
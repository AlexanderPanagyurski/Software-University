using Raiding.Core.Interfaces;
using Raiding.Exceptions;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private ICollection<BaseHero> baseHeroes = new List<BaseHero>();
        public Engine()
        {

        }
        public void Run()
        {
            int count = int.Parse(Console.ReadLine());
            int counter = 0;
            while (count != counter)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    var hero = CreateHero(name, heroType);
                    this.baseHeroes.Add(hero);
                    counter++;
                }
                catch (InvalidTypeOfHeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;

            foreach (var baseHero in this.baseHeroes)
            {
                Console.WriteLine(baseHero.CastAbility());
                totalPower += baseHero.Power;
            }
            if (bossPower < totalPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
        private BaseHero CreateHero(string name, string heroType)
        {
            BaseHero baseHero = null;

            if (heroType == "Paladin")
            {
                baseHero = new Paladin(name);
            }
            else if (heroType == "Druid")
            {
                baseHero = new Druid(name);
            }
            else if (heroType == "Rogue")
            {
                baseHero = new Rogue(name);
            }
            else if (heroType == "Warrior")
            {
                baseHero = new Warrior(name);
            }
            if (baseHero == null)
            {
                throw new InvalidTypeOfHeroException();
            }

            return baseHero;
        }
    }
}

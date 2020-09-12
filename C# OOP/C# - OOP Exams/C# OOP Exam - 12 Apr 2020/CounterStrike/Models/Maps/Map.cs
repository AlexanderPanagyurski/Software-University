using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string Start(ICollection<IPlayer> players)
        {

            while (true)
            {
                var terrorists = players.Where(p => p.GetType().Name == "Terrorist" && p.IsAlive).ToList().AsReadOnly();
                var counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist" && p.IsAlive).ToList().AsReadOnly();


                if (terrorists.Count == 0)
                {
                    return "Counter Terrorist wins!";
                }
                if (counterTerrorists.Count == 0)
                {
                    return "Terrorist wins!";
                }
                foreach (var counterTerrorist in counterTerrorists)
                {
                    if (counterTerrorist.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                    }
                }
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counterTerrorist in counterTerrorists)
                        {
                            if (counterTerrorist.IsAlive)
                            {
                                terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                            }
                        }
                    }
                }
            }
        }
    }
}

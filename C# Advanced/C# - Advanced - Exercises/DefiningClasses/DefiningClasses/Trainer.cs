using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }
        private int BadgesCount;
        private List<Pokemon> Pokemons = new List<Pokemon>();

        public Trainer(string name)
        {
            Name = name;
            BadgesCount = 0;
        }
        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
        public bool ContainsPokemon(Pokemon pokemon)
        {
            return Pokemons.Contains(pokemon);
        }
        public bool ContainsElement(string element)
        {
            bool containsElement = false;
            foreach (var pokemon in Pokemons)
            {
                if (pokemon.Element == element)
                {
                    containsElement = true;
                    break;
                }
            }
            return containsElement;
        }
        public void AddBadge()
        {
            BadgesCount++;
        }
        public void ReduceHealth(int amount)
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Heath -= amount;
                if (Pokemons[i].Heath <= 0)
                {
                    Pokemons.Remove(Pokemons[i]);
                }
            }
        }
        public int GetBadgesCount()
        {
            return BadgesCount;
        }
        public int GetPokemonsCount()
        {
            return Pokemons.Count;
        }
    }
}

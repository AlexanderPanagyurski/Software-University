using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var trainersDictionary = new Dictionary<string, Trainer>();

            while (command != "Tournament")
            {
                var splitCommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = splitCommand[0];
                string pokemonName = splitCommand[1];
                string pokemonElement = splitCommand[2];
                int pokemonHealth = int.Parse(splitCommand[3]);

                if (!trainersDictionary.ContainsKey(trainerName))
                {
                    trainersDictionary.Add(trainerName, new Trainer(trainerName));
                }

                Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainersDictionary[trainerName].ContainsPokemon(currPokemon))
                {
                    trainersDictionary[trainerName].AddPokemon(currPokemon);
                }

                command = Console.ReadLine();
            }
            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainersDictionary)
                {
                    Trainer currTrainer = trainer.Value;
                    if (currTrainer.ContainsElement(command))
                    {
                        currTrainer.AddBadge();
                    }
                    else
                    {
                        currTrainer.ReduceHealth(10);
                    }
                }
                command =Console.ReadLine();
            }
            foreach (var trainer in trainersDictionary.OrderByDescending(x=>x.Value.GetBadgesCount()))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.GetBadgesCount()} {trainer.Value.GetPokemonsCount()}");
            }
        }
    }
}

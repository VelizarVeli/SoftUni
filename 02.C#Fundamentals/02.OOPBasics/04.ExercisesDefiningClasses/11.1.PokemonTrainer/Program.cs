using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._1.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] inp = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = inp[0];
                string pokemonName = inp[1];
                string pokemonElement = inp[2];
                int pokemonHealth = int.Parse(inp[3]);

                Trainer currentTrainer = trainers.FirstOrDefault(a => a.Name == trainerName);
                if (currentTrainer == null)
                {
                    Trainer trainer = new Trainer(trainerName, pokemonName, pokemonElement, pokemonHealth);
                    trainers.Add(trainer);
                }
                else
                {
                    Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    currentTrainer.Pokemons.Add(pokemon);
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(a => a.Element == input))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(a=>a.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.Family_Tree
{
    class StartUp
    {
        static void Main()
        {
            string input;

            List<Pokemon> pokemons = new List<Pokemon>();

            while ((input = Console.ReadLine()) != "wubbalubbadubdub")
            {
                string[] inp = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

                if (inp.Length == 3)
                {
                    string name = inp[0];
                    string type = inp[1];
                    int index = int.Parse(inp[2]);

                    var currentPokemon = pokemons.FirstOrDefault(a => a.Name == name);

                    if (currentPokemon != null)
                    {
                        Evolution currentEvol = new Evolution(type, index);
                        currentPokemon.Evolutions.Add(currentEvol);
                    }
                    else
                    {
                        var pokem = new Pokemon(name,type, index);
                        pokemons.Add(pokem);
                    }
                }
                else
                {
                    string name = inp[0];

                    Pokemon navlek = pokemons.FirstOrDefault(a => a.Name == name);

                    if (navlek != null)
                    {
                        Console.WriteLine($"# {navlek.Name}");
                        foreach (var evol in navlek.Evolutions)
                        {
                            Console.WriteLine($"{evol.Type} <-> {evol.Index}");
                        }
                    }
                }
            }

            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"# {pokemon.Name}");
                foreach (var evolution in pokemon.Evolutions.OrderByDescending(a => a.Index))
                {
                    Console.WriteLine($"{evolution.Type} <-> {evolution.Index}");
                }
            }
        }

        public class Pokemon
        {
            public string Name { get; set; }
            public List<Evolution> Evolutions { get; set; }

            public Pokemon(string name, string type, int index)
            {
                this.Name = name;
                var evol = new Evolution(type, index);

                this.Evolutions = new List<Evolution>();
                Evolutions.Add(evol);
            }
        }

        public class Evolution
        {
            public string Type { get; set; }
            public int Index { get; set; }

            public Evolution(string type, int index)
            {
                this.Type = type;
                this.Index = index;
            }
        }
    }
}
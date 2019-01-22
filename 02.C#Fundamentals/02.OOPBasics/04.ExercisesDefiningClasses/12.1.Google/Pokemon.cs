using System;
using System.Collections.Generic;

public class Pokemon
{
    public string Name { get; set; }
    public string Type { get; set; }

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    public static void PrintPokemons(List<Pokemon> pokemons)
    {
        foreach (var poke in pokemons)
        {
            Console.WriteLine($"{poke.Name} {poke.Type}");
        }
    }
}
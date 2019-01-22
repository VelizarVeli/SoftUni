using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int numberOfBadges;
    public List<Pokemon> Pokemons { get; set; }

    public string Name
    {
        get { return name; }
        set { name = value; }

    }

    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }


    public Trainer(string name, string pokemonName, string pokemonElement, int pokemonHealth)
    {
        this.name = name;
        this.Pokemons = new List<Pokemon>();
        Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
        Pokemons.Add(pokemon);
    }
}
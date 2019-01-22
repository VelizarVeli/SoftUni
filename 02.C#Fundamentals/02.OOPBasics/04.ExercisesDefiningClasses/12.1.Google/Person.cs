using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Company CompanyName { get; set; }
    public Car CarName { get; set; }
    public List<Relative> Relatives { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Relatives = new List<Relative>();
    }

    public Person(string name, string companyName, string department, decimal salary)
    : this(name)
    {
        this.CompanyName = new Company(companyName, department, salary);
    }

    public Person(string name, string pokemonName, string pokemonType)
    : this(name)
    {
        this.Pokemons = new List<Pokemon>();
        Pokemon pokemon = new Pokemon(pokemonName, pokemonType);
        Pokemons.Add(pokemon);
    }

    public Person(string name, string RelativeName, string birthday, string type)
    : this(name)
    {
        this.Relatives = new List<Relative>();
        Relative parent = new Relative(RelativeName, birthday, type);
        Relatives.Add(parent);
    }

    public Person(string name, string model, int speed)
    : this(name)
    {
        this.CarName = new Car(model, speed);
    }

    public override string ToString()
    {
        StringBuilder pokes = new StringBuilder();
        foreach (var pokemon in Pokemons)
        {
            pokes.AppendFormat($"\n{pokemon.Name} {pokemon.Type}");
        }
        StringBuilder parenti = new StringBuilder();
        foreach (var moruk in Relatives.Where(a => a.Type=="parent"))
        {
            parenti.AppendFormat($"\n{moruk.Name} {moruk.Birthday}");
        }
        StringBuilder childri = new StringBuilder();
        foreach (var child in Relatives.Where(a => a.Type == "child"))
        {
            childri.AppendFormat($"\n{child.Name} {child.Birthday}");
        }

        string pokemoni = pokes.ToString();
        var result = $"{this.Name}";
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.CompanyName == null ? "Company:" + Environment.NewLine: $"Company: {this.CompanyName}");

        result = string.Concat(result, this.CarName == null ? "Car:"+ Environment.NewLine : $"Car: {this.CarName}");

        result = string.Concat(result, this.Pokemons.Count == 0 ? "Pokemon:" : $"Pokemon: {pokemoni}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Pokemons.Count == 0 ? "Parents:" : $"Parents: {parenti}");
        result = string.Concat(result, Environment.NewLine);
        result = string.Concat(result, this.Pokemons.Count == 0 ? "Children:" : $"Children: {childri}");

        return result;
    }
}
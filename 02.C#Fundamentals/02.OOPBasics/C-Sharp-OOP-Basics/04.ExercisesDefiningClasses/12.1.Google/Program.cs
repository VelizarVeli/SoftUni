using System;
using System.Collections.Generic;

namespace _12._1.Google
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inp = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string prop = inp[1];
                string name = inp[0];

                switch (prop)
                {
                    case "company":
                        string companyName = inp[2];
                        string department = inp[3];
                        decimal salary = decimal.Parse(inp[4]);

                        if (!people.ContainsKey(name))
                        {
                            Person person = new Person(name, companyName, department, salary);
                            people.Add(name, person);
                        }
                        else
                        {
                            people[name].CompanyName = new Company(companyName, department, salary);
                        }
                        break;
                    case "pokemon":
                        string pokemonName = inp[2];
                        string pokemonType = inp[3];

                        if (!people.ContainsKey(name))
                        {
                            Person person = new Person(name, pokemonName, pokemonType);
                            people.Add(name, person);
                        }
                        else
                        {
                            people[name].Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        }
                        break;
                    case "parents":
                        string parentName = inp[2];
                        string parentBirthDay = inp[3];

                        if (!people.ContainsKey(name))
                        {
                            Person person = new Person(name, parentName, parentBirthDay, "parent");
                            people.Add(name, person);
                        }
                        else
                        {
                            people[name].Relatives.Add(new Relative(parentName, parentBirthDay, "parent"));
                        }
                        break;
                    case "children":
                        string childName = inp[2];
                        string childBirthDay = inp[3];

                        if (!people.ContainsKey(name))
                        {
                            Person person = new Person(name, childName, childBirthDay, "child");
                            people.Add(name, person);
                        }
                        else
                        {
                            people[name].Relatives.Add(new Relative(childName, childBirthDay, "child"));
                        }
                        break;
                    case "car":
                        string model = inp[2];
                        int speed = int.Parse(inp[3]);

                        if (!people.ContainsKey(name))
                        {
                            Person person = new Person(name, model, speed);
                            people.Add(name, person);
                        }
                        else
                        {
                            people[name].CarName = new Car(model, speed);
                        }
                        break;
                }
            }

            string personInfo = Console.ReadLine();

            Print(people, personInfo);
        }

        private static void Print(Dictionary<string, Person> people, string personInfo)
        {
            Console.WriteLine(people[personInfo]);
        }
    }
}

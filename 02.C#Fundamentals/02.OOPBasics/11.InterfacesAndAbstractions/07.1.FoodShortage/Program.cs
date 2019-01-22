using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._1.BorderControl
{
    class Program
    {
        static void Main()
        {
            int counter = int.Parse(Console.ReadLine());

            List<IName> humans = new List<IName>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inp = input.Split();
                string name = inp[0];
                if (counter > 0)
                {
                    if (inp.Length == 4)
                    {
                        int age = int.Parse(inp[1]);
                        string id = inp[2];
                        string birthdate = inp[3];

                        Citizen citizen = new Citizen(name, age, id, birthdate);
                        humans.Add(citizen);
                    }

                    else if (inp.Length == 3)
                    {
                        int age = int.Parse(inp[1]);
                        string group = inp[2];

                        Rebel rebel = new Rebel(name, age, group);
                        humans.Add(rebel);
                    }
                }

                else
                {
                    var human = humans.FirstOrDefault(a => a.Name == name);

                    if (human != null)
                    {
                        human.BuyFood();
                    }
                }

                counter--;
            }

            int food = humans.Select(a => a.Food).Sum();
           
            Console.WriteLine(food);
        }
    }
}

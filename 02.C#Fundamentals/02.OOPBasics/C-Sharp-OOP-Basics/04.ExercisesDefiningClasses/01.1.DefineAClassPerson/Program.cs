using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._1.DefineAClassPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            MiddleAged midleAgers = new MiddleAged();
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person member = new Person(input[0], int.Parse(input[1]));

                midleAgers.CollectMembers(member);
            }

            foreach (var person in midleAgers.GetMiddleAged())
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}

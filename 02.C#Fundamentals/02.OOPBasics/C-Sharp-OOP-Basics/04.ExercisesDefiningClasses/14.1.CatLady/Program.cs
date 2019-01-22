using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._1.CatLady
{
    class Program
    {
        static void Main()
        {
            List<Cat> cats = new List<Cat>();

            string input;

            while ((input = Console.ReadLine())!= "End")
            {
                string breed = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                string name = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1];
                decimal specific = decimal.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                switch (breed)
                {
                    case "Siamese":
                        Siamese siamese = new Siamese(name,specific);
                        cats.Add(siamese);
                        break;
                    case "Cymric":
                        Cymric cymric = new Cymric(name,specific);
                        cats.Add(cymric);
                        break;
                    case "StreetExtraordinaire":
                        StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire(name, specific);
                        cats.Add(streetExtraordinaire);
                        break;
                }
            }

            string catName = Console.ReadLine();
            var currentCat = cats.FirstOrDefault(a => a.Name == catName);
            Console.WriteLine(currentCat);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _9_Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> materials = new SortedDictionary<string, int>();
            SortedDictionary<string, int> allMaterials = new SortedDictionary<string, int>();
            string remember = null;
            bool fragments = false;
            bool shards = false;
            bool motes = false;

            string input = Console.ReadLine().ToLower();
            string[] splitedInput = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i <= splitedInput.Length - 1; i++)
            {
                if (i % 2 != 0)
                {
                    if (!allMaterials.ContainsKey(splitedInput[i]))
                    {
                        allMaterials.Add(splitedInput[i], 0);
                    }
                    allMaterials[splitedInput[i]] += int.Parse(splitedInput[i - 1]);

                    if (splitedInput[i] == "shards" || splitedInput[i] == "fragments" || splitedInput[i] == "motes")
                    {
                        if (splitedInput[i] == "fragments")
                        {
                            fragments = true;
                        }
                        if (splitedInput[i] == "shards")
                        {
                            shards = true;
                        }
                        if (splitedInput[i] == "motes")
                        {
                            motes = true;
                        }
                        if (!materials.ContainsKey(splitedInput[i]))
                        {
                            materials.Add(splitedInput[i], 0);
                        }
                        materials[splitedInput[i]] += int.Parse(splitedInput[i - 1]);
                        if (materials[splitedInput[i]] >= 250)
                        {

                            if (splitedInput[i] == "fragments")
                            {
                                Console.WriteLine("Valanyr obtained!");
                                remember = "fragments";
                                break;
                            }
                            if (splitedInput[i] == "motes")
                            {
                                Console.WriteLine("Dragonwrath obtained!");
                                remember = "motes";
                                break;
                            }
                            if (splitedInput[i] == "shards")
                            {
                                Console.WriteLine("Shadowmourne obtained!");
                                remember = "shards";
                                break;
                            }
                        }
                    }
                }

            }


            if (remember == "shards")
            {
                materials["shards"] -= 250;

            }
            if (remember == "motes")
            {
                materials["motes"] -= 250;

            }

            if (remember == "fragments")
            {

                materials["fragments"] -= 250;

            }

            if (fragments == false)
            {
                materials.Add("fragments", 0);
            }
            if (shards == false)
            {
                materials.Add("shards", 0);
            }
            if (motes == false)
            {
                materials.Add("motes", 0);
            }
            foreach (var item in materials.OrderByDescending(x => x.Value))
            {

                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in allMaterials)
            {
                if (item.Key == "fragments" || item.Key == "motes" || item.Key == "shards")
                {
                    continue;
                }
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
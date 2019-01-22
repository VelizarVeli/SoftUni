using System;
using System.Collections.Generic;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, string>> data = new Dictionary<string, SortedDictionary<string, string>>();
            int infoIndex = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "end transmissions")
            {
                string name = input[0];

                if (!data.ContainsKey(name))
                {
                    data.Add(name, new SortedDictionary<string, string>());
                }
                string[] keyValue = input[1].Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var keyVal in keyValue)
                {
                    string[] keyAndVal = keyVal.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    if (!data[name].ContainsKey(keyAndVal[0]))
                    {
                        data[name].Add(keyAndVal[0], keyAndVal[1]);
                    }
                    else
                    {
                        data[name][keyAndVal[0]] = keyAndVal[1];
                    }
                }
                input = Console.ReadLine().Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            }
            string[] order = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string killName = order[1];

            foreach (var name in data)
            {
                string nam = name.Key;
                SortedDictionary<string, string> keyVa = name.Value;

                if (nam == killName)
                {
                    int targetIndex = 0;
                    Console.WriteLine($"Info on {killName}:");
                    foreach (var keyValueP in keyVa)
                    {
                        Console.WriteLine($"---{keyValueP.Key}: {keyValueP.Value}");
                        targetIndex += keyValueP.Key.Length;
                        targetIndex += keyValueP.Value.Length;
                    }
                    Console.WriteLine($"Info index: {targetIndex}");
                    if (targetIndex >= infoIndex)
                    {
                        Console.WriteLine("Proceed");
                    }
                    else
                    {
                        Console.WriteLine($"Need {infoIndex - targetIndex} more info.");
                    }
                }
                
            }
        }
    }
}
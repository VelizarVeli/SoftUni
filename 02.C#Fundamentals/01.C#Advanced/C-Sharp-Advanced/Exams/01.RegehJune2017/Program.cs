using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.RegehJune2017
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\[[a-zA-Z]+<([\d]+)REGEH([\d]+)>[\w]+\]";
            Queue<int> indeces = new Queue<int>();
            foreach (Match m in Regex.Matches(input, pattern))
            {
                int group1 = int.Parse(m.Groups[1].Value);
                int group2 = int.Parse(m.Groups[2].Value);
                indeces.Enqueue(group1);
                indeces.Enqueue(group2);
            }
            string word = string.Empty;
            int count = indeces.Count;
            int index = 0;
            
            for (int i = 0; i < count; i++)
            {
                index += indeces.Dequeue();
                char currentLetter = input[index];
                word += currentLetter;
            }
            Console.WriteLine(word);
        }
    }
}

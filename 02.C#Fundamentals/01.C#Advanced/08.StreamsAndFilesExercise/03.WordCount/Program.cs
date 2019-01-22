using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        { 
            StreamReader reader = new StreamReader("../../words.txt");
            Dictionary<string, int> wordsAndCounters = new Dictionary<string, int>();
            var readLine = reader.ReadLine();
            
            while (true)
            {
                if (!wordsAndCounters.ContainsKey(readLine))
                {
                    wordsAndCounters.Add(readLine,0);
                }

                readLine = reader.ReadLine();

                if (readLine == null)
                {
                    break;
                }
            }


            string path = @"../../text.txt";
           
            string[] readText = File.ReadAllText(path).Split(new []{' ', '-', '.', '!', '?',','}, StringSplitOptions.RemoveEmptyEntries);

            for(int word = 0; word < wordsAndCounters.Count;word++)
            {
                
                for (int i = 0; i < readText.Length; i++)
                {
                    var item = wordsAndCounters.ElementAt(word);
                    string wordInText = readText[i];
                    string checkWord = item.Key;
                    if (checkWord.ToLower() == wordInText.ToLower())
                    {
                        wordsAndCounters[checkWord]++;
                    }
                }
            }
            foreach (var word in wordsAndCounters.OrderByDescending(a => a.Value))
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}

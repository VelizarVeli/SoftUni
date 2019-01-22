using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string pattern = @"(\^{6,}|\#{6,}|\${6,}|\@{6,})(\w*|\W*)(\1)";
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                }
                else if (Regex.IsMatch(input[i], pattern) == false)
                {
                    Console.WriteLine($"ticket \"{input[i]}\" - no match");
                }
                else
                {
                    var match = Regex.Match(input[i], pattern);

                    string temp = match.Groups[1].Value;
                    if (temp.Length == 10)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - 10{temp[0]} Jackpot!");
                    }
                    else
                    {
                        int count = 0;
                        for (int j = 0; j < temp.Length; j++)
                        {
                            count++;
                        }
                        Console.WriteLine($"ticket \"{input[i]}\" - {count}{temp[0]}");
                    }

                }

            }

        }
    }
}
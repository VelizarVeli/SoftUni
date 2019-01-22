using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace _03.CryptoBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            long rows = long.Parse(Console.ReadLine());
            StringBuilder data = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                data.Append(Console.ReadLine());
            }
            string input = data.ToString();
            char[] checkForBlockChains = input.ToCharArray();
            string testy = String.Empty;
            bool bracket = false;
            bool curly = false;

            List<string> blockchain = new List<string>();

            foreach (var chary in checkForBlockChains)
            {
                if (bracket)
                {
                    if (chary != '}')
                    {
                        testy += chary;
                    }
                    if (chary == ']')
                    {
                        blockchain.Add(testy);
                        bracket = false;
                        testy = String.Empty;
                        continue;
                    }
                    if (chary == '[')
                    {
                        testy = string.Empty;
                    }
                    if (chary == '}')
                    {
                        bracket = false;
                        testy = String.Empty;
                        break;
                    }
                }

                if (curly)
                {
                    if (chary != ']')
                    {
                        testy += chary;
                    }
                    if (chary == '}')
                    {
                        blockchain.Add(testy);
                        curly = false;
                        testy = String.Empty;
                        continue;
                    }
                    if (chary == '{')
                    {
                        testy = string.Empty;
                    }
                    if (chary == ']')
                    {
                        curly = false;
                        testy = String.Empty;
                        break;
                    }
                }

                if (chary == '[' && curly == false)
                {
                    bracket = true;
                }

                if (chary == '{' && bracket == false)
                {
                    curly = true;
                }
            }
            string pattern = @"[\d]+";
            string nonPrintable = @"\p{C}+";
            List<int> numbers = new List<int>();

            foreach (var blChain in blockchain)
            {
                bool yes = false;
                foreach (Match m in Regex.Matches(blChain, pattern))
                {
                    int valio = m.Value.Length;
                    foreach (Match k in Regex.Matches(blChain, nonPrintable))
                    {
                        yes = true;
                        break;
                    }
                    if (valio % 3 != 0)
                    {
                        break;
                    }
                    else
                    {
                        string numby = m.Value;
                        for (int i = 0; i < valio; i += 3)
                        {
                            string numb3 = numby.Substring(0, 3);
                            int number3 = int.Parse(numb3) - blChain.Length - 1;
                            numbers.Add(number3);
                            numby = numby.Substring(3, numby.Length - 3);
                        }
                    }
                    if (yes)
                    {
                        break;
                    }
                }
            }
            foreach (var charr in numbers)
            {
                Console.Write((char)charr);
            }
            Console.WriteLine();
        }
    }
}

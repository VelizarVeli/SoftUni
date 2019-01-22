using System;

namespace _06.LettersCombination
{
    class Program
    {
        static void Main()
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = a; k <= b; k++)
                    {
                        if (i != c && j != c && k != c)
                        {
                            counter++;
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}

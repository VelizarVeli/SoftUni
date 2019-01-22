using System;

namespace _04.FootballLeague
{
    class Program
    {
        static void Main()
        {
            double capacity = double.Parse(Console.ReadLine());
            double fens = double.Parse(Console.ReadLine());
            double A = 0;
            double B = 0;
            double V = 0;
            double G = 0;
            for (int i = 1; i <= fens; i++)
            {
                string sector = Console.ReadLine().ToLower();

                if (sector == "a")
                {
                    A++;
                }
                if (sector == "b")
                {
                    B++;
                }
                if (sector == "v")
                {
                    V++;
                }
                if (sector == "g")
                {
                    G++;
                }
            }
            Console.WriteLine($"{A / fens * 100:f2}%");
            Console.WriteLine($"{B / fens * 100:f2}%");
            Console.WriteLine($"{V / fens * 100:f2}%");
            Console.WriteLine($"{G / fens * 100:f2}%");
            Console.WriteLine($"{fens / capacity * 100:f2}%");
        }
    }
}

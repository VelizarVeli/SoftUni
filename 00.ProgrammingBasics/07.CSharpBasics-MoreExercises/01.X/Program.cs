using System;

namespace _01.X
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int spaces = 0 ;
            int insSpaces = (n - 2) - (spaces * 2);
            int downSpaces = (n / 2) - 1;
            int downInsSpaces = 1;
            
            if (n > 3)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i <= n / 2 - 1)
                    {
                        Console.WriteLine("{0}x{1}x", new string(' ', spaces), new string(' ', insSpaces));
                        spaces++;
                        insSpaces -= 2;
                    }
                    if (n / 2 == i)
                    {
                        Console.WriteLine("{0}x", new string(' ', n / 2));
                    }
                    if (i > n / 2)
                    {

                        Console.WriteLine("{0}x{1}x", new string(' ', downSpaces), new string(' ', downInsSpaces));
                        downSpaces--;
                        downInsSpaces += 2;
                    }
                }
            }
            else
            {
                Console.WriteLine("x x");
                Console.WriteLine(" x ");
                Console.WriteLine("x x");
            }
        }
    }
}

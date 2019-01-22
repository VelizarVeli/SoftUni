using System;

namespace _01.RectangleOf10x10Stars
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            string stars = new string('*', N);

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(stars);
            }
        }
    }
}

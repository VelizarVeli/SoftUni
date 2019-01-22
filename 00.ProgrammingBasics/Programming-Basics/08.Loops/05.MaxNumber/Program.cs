using System;

namespace _05.MaxNumber
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int max = int.Parse(Console.ReadLine());
            

            for (int i = 1; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (num > max)
                {
                    max = num;
                }
            }
            Console.WriteLine(max);
        }
    }
}

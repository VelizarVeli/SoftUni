using System;

namespace _05.InvalidNumber
{
    class Program
    {
        static void Main()
        {
            int integer = int.Parse(Console.ReadLine());
            bool check = (integer >= 100 && integer <= 200) || integer == 0;

            if (!check)
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}

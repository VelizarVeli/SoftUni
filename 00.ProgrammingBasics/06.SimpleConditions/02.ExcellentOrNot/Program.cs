using System;

namespace _02.ExcellentOrNot
{
    class Program
    {
        static void Main()
        {
            var grade = double.Parse(Console.ReadLine());
            if (grade >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
            else Console.WriteLine("Not excellent.");
        }
    }
}

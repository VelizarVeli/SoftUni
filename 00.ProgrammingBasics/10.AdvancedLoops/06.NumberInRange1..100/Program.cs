using System;

namespace _06.NumberInRange1._._100
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a number in the range [1...100]: ");
            int n = int.Parse(Console.ReadLine());
         
     
                while (n > 100 || n < 1)
                {
                    Console.WriteLine("Invalid number");
                    n = int.Parse(Console.ReadLine());
                }
            
                Console.WriteLine($"The number is: {n}");
        }
    }
}

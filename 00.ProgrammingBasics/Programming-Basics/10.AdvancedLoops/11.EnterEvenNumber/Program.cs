using System;

namespace _11.EnterEvenNumber
{
    class Program
    {
        static void Main()
        {
            

            while (true)
            {
                try
                {
                    Console.Write("Enter even number: ");
                    int n = int.Parse(Console.ReadLine());

                    if (n % 2 == 0)
                    {
                        Console.WriteLine($"Even number entered: {n}");
                        break;
                    }
                    else
                    Console.WriteLine("The number is not even.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }
    }
}

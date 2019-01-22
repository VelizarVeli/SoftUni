using System;

namespace _17.DigitsOperations
{
    class Program
    {
        static void Main()
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            string opearator = Console.ReadLine();
            var result = 0.0;
            string evenodd = "";

            if (opearator == "+")
            {
                result = N1 + N2;
                if (result % 2 == 0)
                {
                    evenodd = "even";
                }
                else
                    evenodd = "odd";
                Console.WriteLine($"{N1} + {N2} = {result} - {evenodd}");
            }
            else if (opearator == "-")
            {
                result = N1 - N2;
                if (result % 2 == 0)
                {
                    evenodd = "even";
                }
                else
                    evenodd = "odd";
                Console.WriteLine($"{N1} - {N2} = {result} - {evenodd}");
            }
            else if (opearator == "*")
            {
                result = N1 * N2;
                if (result % 2 == 0)
                {
                    evenodd = "even";
                }
                else
                    evenodd = "odd";
                Console.WriteLine($"{N1} * {N2} = {result} - {evenodd}");
            }
            else if (opearator == "/")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    result = N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {result:f2}");
                }
            }

            else if (opearator == "%")
            {
                if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
                else
                {
                    result = N1 % N2;
                    Console.WriteLine($"{N1} % {N2} = {result}");
                }
            }
        }
    }
}

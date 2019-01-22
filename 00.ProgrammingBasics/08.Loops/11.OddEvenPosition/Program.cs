using System;

namespace _11.OddEvenPosition
{
    class Program
    {
        static void Main()
        {
            int entr = int.Parse(Console.ReadLine());

            double oddSum = 0.0;
            double oddMin = 2147483640.0;
            double oddMax = -2147483640.0;
            
            double evenSum = 0.0;
            double evenMin = 2147483640.0;
            double evenMax = -2147483640.0;

            for (int i = 1; i <= entr; i++)
            {
                double nums = double.Parse(Console.ReadLine());

                if (i % 2 != 0)
                {
                    oddSum += nums;

                    if (oddMin > nums)
                    {
                        oddMin = nums;
                    }
                    if (oddMax < nums)
                    {
                        oddMax = nums;
                    }

                }
                if (i % 2 == 0)
                {
                    evenSum += nums;

                    if (evenMin > nums)
                    {
                        evenMin = nums;
                    }
                    if (evenMax < nums)
                    {
                        evenMax = nums;
                    }
                }
            }
            Console.WriteLine($"OddSum = {oddSum},");
            if (oddMin == 2147483640.0)
            {
                Console.WriteLine("OddMin No");
            }
            else
            {
                Console.WriteLine($"OddMin = {oddMin},");
            }

            if (oddMax == -2147483640.0)
            {
                Console.WriteLine("OddMax No");
            }
            else
            {
                Console.WriteLine($"OddMax = {oddMax},");
            }
            Console.WriteLine($"EvenSum = {evenSum},");

            if (evenMin == 2147483640.0)
            {
                Console.WriteLine("EvenMin No");
            }
            else
            {
                Console.WriteLine($"EvenMin = {evenMin},");
            }
            if (evenMax == -2147483640.0)
            {
                Console.WriteLine("EvenMax No");
            }
            else
            {
                Console.WriteLine($"EvenMax = {evenMax},");
            }
        }
    }
}

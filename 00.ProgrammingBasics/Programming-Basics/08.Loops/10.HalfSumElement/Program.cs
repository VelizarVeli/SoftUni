using System;

namespace _10.HalfSumElement
{
    class Program
    {
        static void Main()
        {
            int entr = int.Parse(Console.ReadLine());

            int firstNum = int.Parse(Console.ReadLine());
            int max = firstNum;
            int sum = 0;
            int wholeSum = 0;
            for (int i = 1; i < entr; i++)
            {
                int nums = int.Parse(Console.ReadLine());

                if (nums > max)
                {
                    max = nums;
                }
                sum += nums;
            }
            wholeSum = sum + firstNum;

            if (wholeSum - max == max)
            {
                Console.WriteLine($"Yes Sum = {max}");
            }
            else
            {
                Console.WriteLine($"No Diff = {Math.Abs((wholeSum - max) - max)}");
            }
        }
    }
}

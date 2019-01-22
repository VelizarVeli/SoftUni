using System;

namespace _12.EqualPairs
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int previousSum = 0;
            int maxDiff = 0;
            bool allPairsAreEqual = true;
            // for ...
            // 1. четем си числата от конзолата
            // 2. смятаме сумата
            // 3. сумата по-голяма ли е от предишната?
            // 4. разликата максимална ли е?
            // 5. previousSum = sum;
            for (int i = 0; i < n; i++)
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());

                int sum = firstNum + secondNum;

                if (sum != previousSum && i != 0)
                {
                    allPairsAreEqual = false;
                    int difference = Math.Abs(sum - previousSum);

                    if (difference > maxDiff)
                    {
                        maxDiff = difference;
                    }
                }
                previousSum = sum;
            }
            if (allPairsAreEqual)
            {
                Console.WriteLine($"Yes, value={previousSum}");
            }
            else
            {
                Console.WriteLine(($"No, maxDiff={maxDiff}"));
            }
        }
    }
}

using System;

namespace _09.SumDigits
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int currentNum = 0;
            while(n != 0)
            {
                currentNum = n % 10;
                sum = currentNum + sum;
                n = n / 10;
            }
            Console.WriteLine(sum);
        }
    }
}

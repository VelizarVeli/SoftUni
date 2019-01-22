using System;

namespace _15.SmartLily
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            double WM = double.Parse(Console.ReadLine());
            int toysPrice = int.Parse(Console.ReadLine());
            double money = 0.0;
            double moneyCounter = 0;

            int toysCounter = 0;

            for (int i = 1; i <= N; i++)
            {
                if (i % 2 != 0)
                {
                    toysCounter++;
                }
                else
                {
                    moneyCounter += 10;
                    money += moneyCounter - 1;
                }
            }
            double allMoney = money + toysCounter * toysPrice;
            if (allMoney < WM)
            {
                Console.WriteLine($"No! {Math.Abs(allMoney - WM):f2}");
            }
            else
            {
                Console.WriteLine($"Yes! {Math.Abs(allMoney - WM):f2}");
            }
        }
    }
}

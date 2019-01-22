using System;

namespace _02.ToyShop
{
    class Program
    {
        static void Main()
        {
            double excursionPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int teddyBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int lorries = int.Parse(Console.ReadLine());

            double puzzleProfit = puzzles * 2.6;
            double dollProfit = dolls * 3;
            double teddyBearProfit = teddyBears * 4.1;
            double minionsProfit = minions * 8.2;
            double lorryProfit = lorries * 2;

            double profit = puzzleProfit + dollProfit + teddyBearProfit + minionsProfit + lorryProfit;

            if (puzzles + dolls + teddyBears + minions + lorries >= 50)
            {
                profit = profit - (profit * 0.25);
            }
            profit = profit - (profit * 0.1);

            if (profit >= excursionPrice)
            {
                Console.WriteLine($"Yes! {profit - excursionPrice:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {excursionPrice - profit:f2} lv needed.");
            }
        }
    }
}

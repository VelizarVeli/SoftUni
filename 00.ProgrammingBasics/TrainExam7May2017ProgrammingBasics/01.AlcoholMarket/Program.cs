using System;

namespace _01.AlcoholMarket
{
    class Program
    {
        static void Main()
        {
            double priceWiskey = double.Parse(Console.ReadLine());
            double beer = double.Parse(Console.ReadLine());
            double wine = double.Parse(Console.ReadLine());
            double rakia = double.Parse(Console.ReadLine());
            double wiskey = double.Parse(Console.ReadLine());

            double priceRakia = priceWiskey / 2;
            double priceWine = priceRakia - (0.4 * priceRakia);
            double priceBeer = priceRakia - (0.8 * priceRakia);
            double sum = (priceWiskey * wiskey) + (priceBeer * beer) + (priceWine * wine) + (priceRakia * rakia); 
            Console.WriteLine($"{sum:f2}");
        }
    }
}

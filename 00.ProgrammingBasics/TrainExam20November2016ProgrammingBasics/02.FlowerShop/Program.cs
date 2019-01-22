using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.FlowerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnolii = double.Parse(Console.ReadLine());
            double zumbuli = double.Parse(Console.ReadLine());
            double rozi = double.Parse(Console.ReadLine());
            double kaktusi = double.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double magnoliiCost = magnolii * 3.25;
            double zumbuliCost = zumbuli * 4;
            double roziCost = rozi * 3.5;
            double kaktusiCost = kaktusi * 8;
            double totalCost = (magnoliiCost + zumbuliCost + roziCost + kaktusiCost) * 0.95;
            double diff = Math.Abs(presentPrice - totalCost);

            if (totalCost >= presentPrice)
            {
                diff = Math.Floor(diff);
                Console.WriteLine($"She is left with {diff} leva.");
            }
            else
            {
                diff = Math.Ceiling(diff);
                Console.WriteLine($"She will have to borrow {diff} leva.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ParichnaNagrada
{
    class Program
    {
        static void Main(string[] args)
        {
            int parts = int.Parse(Console.ReadLine());
            double pricePerPoint = double.Parse(Console.ReadLine());
            int tochkiTotal = 0;

            for (int i = 1; i <= parts; i++)
            {
            int tochki = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    tochki = tochki * 2;
                }
                tochkiTotal = tochki + tochkiTotal;
            }
            double prize = tochkiTotal * pricePerPoint;
            Console.WriteLine($"The project prize was {prize:f2} lv.");
        }
    }
}

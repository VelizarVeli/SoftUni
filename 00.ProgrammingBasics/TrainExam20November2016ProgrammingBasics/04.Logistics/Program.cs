using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int tovari = int.Parse(Console.ReadLine());
            double mikrobus = 0;
            double kamion = 0;
            double vlak = 0;
            int all = 0;
            for (int i = 0; i < tovari; i++)
            {
                int tonaj = int.Parse(Console.ReadLine());
                all = tonaj + all;
                if (tonaj <= 3)
                {
                    mikrobus = tonaj + mikrobus;
                }
                else if (tonaj > 3 && tonaj <= 11)
                {
                    kamion = kamion + tonaj;
                }
                else if (tonaj >= 12)
                {
                    vlak = vlak + tonaj;
                }
            }
            double mikrobusCost = mikrobus * 200;
            double kamionCost = kamion * 175;
            double vlakCost = vlak * 120;
            double averageCost = (mikrobusCost + kamionCost + vlakCost) / (mikrobus + kamion + vlak);

            Console.WriteLine($"{averageCost:f2}");
            Console.WriteLine($"{mikrobus / all * 100:f2}%");
            Console.WriteLine($"{kamion / all * 100:f2}%");
            Console.WriteLine($"{vlak / all * 100:f2}%");
        }
    }
}

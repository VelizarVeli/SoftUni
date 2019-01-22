using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string trase = Console.ReadLine();

            double juniorsMoney = 0;
            double seniorsMoney = 0;

            if (trase == "trail")
            {
                juniorsMoney = juniors * 5.5;
                seniorsMoney = seniors * 7;
            }
            else if (trase == "cross-country")
            {
                juniorsMoney = juniors * 8;
                seniorsMoney = seniors * 9.5;
            }
            else if (trase == "downhill")
            {
                juniorsMoney = juniors * 12.25;
                seniorsMoney = seniors * 13.75;
            }
            else if (trase == "road")
            {
                juniorsMoney = juniors * 20;
                seniorsMoney = seniors * 21.5;
            }
            double total = juniorsMoney + seniorsMoney;

            if (trase == "cross-country" && juniors + seniors >= 50)
            {
                total = total * 0.75;
            }
            total = total * 0.95;
            Console.WriteLine($"{total:f2}");
        }
    }
}

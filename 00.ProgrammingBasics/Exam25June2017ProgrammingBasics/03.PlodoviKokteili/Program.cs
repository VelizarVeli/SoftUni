using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PlodoviKokteili
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine().ToLower();
            string size = Console.ReadLine().ToLower();
            int broi = int.Parse(Console.ReadLine());

            double price = 0;

            if (size == "small")
            {
                if (fruit == "watermelon")
                {
                    price = 56 * 2 * broi;
                }
                else if (fruit == "mango")
                {
                    price = 36.66 * 2 * broi;
                }
                else if (fruit == "pineapple")
                {
                    price = 42.1 * 2 * broi;
                }
                else if (fruit == "raspberry")
                {
                    price = 20 * 2 * broi;
                }
            }
            else if (size == "big")
            {
                if (fruit == "watermelon")
                {
                    price = 28.7 * 5 * broi;
                }
                else if (fruit == "mango")
                {
                    price = 19.6 * 5 * broi;
                }
                else if (fruit == "pineapple")
                {
                    price = 24.8 * 5 * broi;
                }
                else if (fruit == "raspberry")
                {
                    price = 15.2 * 5 * broi;
                }
            }

            if (price > 1000)
            {
                price = price / 2;
                Console.WriteLine($"{price:f2} lv.");

            }
            else if (price >= 400 && price <= 1000)
            {
                price = price * 0.85;
                Console.WriteLine($"{price:f2} lv.");

            }
            else
                Console.WriteLine($"{price:f2} lv.");
        }
    }
}

using System;

namespace _18.TransportPrice
{
    class Program
    {
        static void Main()
        {
            var km = int.Parse(Console.ReadLine());
            string dn = Console.ReadLine();

            if (km >= 100)
            {
                Console.WriteLine(km * 0.06);
            }

            else if (km >= 20 && km <= 100)
            {
                Console.WriteLine(km * 0.09);
            }

            else if (km < 20)
            {
                if (dn == "day")
                Console.WriteLine(km * 0.79 + 0.70);
                else
                    Console.WriteLine(km * 0.90 + 0.70);
            }
        }
    }
}

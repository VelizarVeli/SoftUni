using System;

namespace _04.Bills
{
    class Program
    {
        static void Main()
        {
            int months = int.Parse(Console.ReadLine());
            double electricity = 0;
            double store = 0;
            double water = 20;
            double internet = 15;

            for (int i = 0; i < months; i++)
            {
                electricity = double.Parse(Console.ReadLine());
                store = electricity + store;
            }

            Console.WriteLine($"Electricity: {store:f2} lv");
            Console.WriteLine($"Water: {water * months:f2} lv");
            Console.WriteLine($"Internet: {internet * months:f2} lv");
            Console.WriteLine($"Other: {((internet * months) + store + (water * months)) * 1.2:f2} lv");
            Console.WriteLine($"Average: {((((internet * months) + store + (water * months)) * 1.2) + (internet * months) + (water * months) + store) / months:f2} lv");

        }
    }
}

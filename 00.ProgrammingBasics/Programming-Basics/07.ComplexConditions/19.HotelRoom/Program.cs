using System;

namespace _19.HotelRoom
{
    class Program
    {
        static void Main()
        {
            string month = Console.ReadLine().ToLower();
            int nights = int.Parse(Console.ReadLine());

            if (month == "may" || month == "october")
            {
                if (nights > 14)
                {
                    Console.WriteLine($"Apartment: {((nights * 65) - (nights * 65) * 0.1):f2} lv.");
                    Console.WriteLine($"Studio: {((nights * 50) - (nights * 50) * 0.3):f2} lv.");
                }
                else if (nights > 7)
                {
                    Console.WriteLine($"Apartment: {(nights * 65):f2} lv.");
                    Console.WriteLine($"Studio: {((nights * 50) - (nights * 50) * 0.05):f2} lv.");
                }
            }
            else if (month == "june" || month == "september")
            {
                if (nights > 14)
                {
                    Console.WriteLine($"Apartment: {((nights * 68.7) - (nights * 68.7) * 0.1):f2} lv.");
                    Console.WriteLine($"Studio: {((nights * 75.2) - (nights * 75.2) * 0.2):f2} lv.");
                }
                else
                {
                    Console.WriteLine($"Apartment: {(nights * 68.7):f2} lv.");
                    Console.WriteLine($"Studio: {(nights * 75.2):f2} lv.");
                }
            }
            else if (month == "july" || month == "august")
            {
                if (nights > 14)
                {
                    Console.WriteLine($"Apartment: {((nights * 77) - (nights * 77) * 0.1):f2} lv.");
                    Console.WriteLine($"Studio: {(nights * 76):f2} lv.");
                }
                else
                {
                    Console.WriteLine($"Apartment: {(nights * 77):f2} lv.");
                    Console.WriteLine($"Studio: {(nights * 76):f2} lv.");
                }
            }
        }
    }
}

using System;

namespace _14.Time_15Minutes
{
    class Program
    {
        static void Main()
        {
            var hour = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());
            var MinPlus15 = minutes + 15;

            if (MinPlus15 > 59)
            {
                hour += 1;
                MinPlus15 -= 60;

                if (hour > 23)
                {
                    hour -= 24;
                }
            }
            if (MinPlus15 < 10)
            {
                Console.WriteLine($"{hour}:0{MinPlus15}");
            }
            else
            Console.WriteLine($"{hour}:{MinPlus15}");
        }
    }
}

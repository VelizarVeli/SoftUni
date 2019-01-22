using System;

namespace _04.GameOfIntervals
{
    class Program
    {
        static void Main()
        {
            int moves = int.Parse(Console.ReadLine());

            double result = 0;
            double from0To9 = 0;
            double from10To19 = 0;
            double from20To29 = 0;
            double from30To39 = 0;
            double from40To50 = 0;
            double invalid = 0;

            for (int i = 0; i < moves; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0 || number > 50)
                {
                    invalid++;
                    result /= 2;
                }
                else if (number >= 0 && number < 10)
                {
                    from0To9++;
                    result += number * 0.2;
                }
                else if (number >= 10 && number < 20)
                {
                    from10To19++;
                    result += number * 0.3;
                }
                else if (number >= 20 && number < 30)
                {
                    from20To29++;
                    result += number * 0.4;
                }
                else if (number >= 30 && number < 40)
                {
                    from30To39++;
                    result += 50;
                }
                else if (number >= 40 && number <= 50)
                {
                    from40To50++;
                    result += 100;
                }
            }
            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {from0To9 * 100 / moves:f2}%");
            Console.WriteLine($"From 10 to 19: {from10To19 * 100 / moves:f2}%");
            Console.WriteLine($"From 20 to 29: {from20To29 * 100 / moves:f2}%");
            Console.WriteLine($"From 30 to 39: {from30To39 * 100 / moves:f2}%");
            Console.WriteLine($"From 40 to 50: {from40To50 * 100 / moves:f2}%");
            Console.WriteLine($"Invalid numbers: {invalid * 100 / moves:f2}%");

        }
    }
}

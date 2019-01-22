using System;

namespace _06.BonusScore
{
    class Program
    {
        static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            double bonus = 0;
            if (input <= 100)
            {
                bonus = 5;
            }
            else if (input > 100 && input <= 1000)
            {
                bonus = input * 0.2;
            }
            else if (input > 1000)
            {
                bonus = input * 0.1;
            }

            if (input % 2 == 0)
            {
                bonus++;
            }
            else if(input % 10 == 5)
            
                bonus += 2;
            
            Console.WriteLine(bonus);
            Console.WriteLine(input + bonus);

        }
    }
}

using System;

namespace _05._1.DateModifier
{
    class StartUp
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            
            global::DateModifier check = new global::DateModifier(first, second);

            Console.WriteLine(check.CalculateDateDifference(first, second));
            
        }
    }
}

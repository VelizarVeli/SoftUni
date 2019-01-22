using System;

namespace _03._1.Ferrari
{
    class Program
    {
        static void Main()
        {
            string driver = Console.ReadLine();
            global::Ferrari ferrari = new global::Ferrari(driver);
            Console.WriteLine(ferrari);
        }
    }
}

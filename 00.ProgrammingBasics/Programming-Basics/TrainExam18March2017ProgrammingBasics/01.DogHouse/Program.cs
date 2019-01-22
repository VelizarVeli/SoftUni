using System;

namespace _01.DogHouse
{
    class Program
    {
        static void Main()
        {
            double A = double.Parse(Console.ReadLine());
            double B = double.Parse(Console.ReadLine());

            double sides = (A * A / 2) * 2;
            double backWall = (A / 2) * (A / 2) + ((A / 2) * (B - A / 2)) / 2;
            double frontWall = backWall - ((A / 5) * (A / 5));
            double green = (sides + backWall + frontWall) / 3;

            double roof = A * A;
            double red = roof / 5;

            Console.WriteLine($"{green:f2}");
            Console.WriteLine($"{red:f2}");

        }
    }
}

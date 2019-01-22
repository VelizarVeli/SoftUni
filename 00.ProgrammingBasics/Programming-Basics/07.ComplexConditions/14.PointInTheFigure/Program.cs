using System;

namespace _14.PointInTheFigure
{
    class Program
    {
        static void Main()
        {
            int h = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            bool isInDownQuadrant = (x > 0 && x < 3 * h) && (y > 0 && y < h);
            bool isInUpperQuadrant = (x > h && x < 2 * h) && (y > h && y < 4 * h);
            bool exceptions = ((x > h && x < 2 * h) & (y == h));

            bool Border = (x >= 0 && x < 3 * h) && (y == 0) || ((x == 0 || x == 3 * h) && (y >= 0 && y <= h) || (x >= 0 && x <= h || 
                x >= 2 * h && x <= 3 * h) && (y == h) || (x == h || x == 2 * h) && (y >= h && y <= 4 * h) || ((x >= h && x <= h * 2) && y == 4 * h));
           

            if (isInDownQuadrant || isInUpperQuadrant || exceptions)
            {
                Console.WriteLine("inside");
            }
            else if (Border)
            {
                Console.WriteLine("border");
            }
            else
                Console.WriteLine("outside");
        }
    }
}

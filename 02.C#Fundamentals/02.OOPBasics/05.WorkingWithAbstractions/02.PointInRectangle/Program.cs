using System;
using System.Linq;

public class Program
{
    static void Main()
    {
        var coords = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var rectangle = new Rectangle(coords[0], coords[1], coords[2], coords[3]);

        var pointsCount = int.Parse(Console.ReadLine());

        for (int pointsCounter = 0; pointsCounter < pointsCount; pointsCounter++)
        {
            var pointCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var point = new Point(pointCoords[0], pointCoords[1]);
            var containsPoint = rectangle.Contains(point);
            Console.WriteLine(containsPoint);
        }
    }
}
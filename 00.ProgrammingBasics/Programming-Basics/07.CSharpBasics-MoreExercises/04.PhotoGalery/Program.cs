using System;

namespace _04.PhotoGalery
{
    class Program
    {
        static void Main()
        {
            int PhotoNumber = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            double photoSize = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: DSC_{PhotoNumber:d4}.jpg");
            Console.WriteLine($"Date Taken: {day:d2}/{month:d2}/{year} {hours:d2}:{minutes:d2}");
            if(photoSize >= 1000 && photoSize < 1000000)
            {
                double Size = photoSize / 1000;
                Console.WriteLine($"Size: {Size}KB");
            }
            else if (photoSize < 1000)
            {
                Console.WriteLine($"Size: {photoSize}B");
            }
            else if (photoSize >= 1000000)
            {
                double Size = photoSize / 1000000;
                Console.WriteLine($"Size: {Size}MB");
            }
            if(width > height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (landscape)");
            }
            else if (width == height)
            {
                Console.WriteLine($"Resolution: {width}x{height} (square)");
            }
           else 
            {
                Console.WriteLine($"Resolution: {width}x{height} (portrait)");
            }
        }
    }
}

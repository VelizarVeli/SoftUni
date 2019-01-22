using System;

namespace _01.RectangleOf10x10Stars
{
    class Program
    {
        static void Main()
        {
            int ten = 10;
            string stars = new string('*', ten);

            for (int i = 0; i < ten; i++)
            {
                Console.WriteLine(stars);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._1.RectangleIntersection
{
    class Program
    {
        static void Main()
        {
            int[] NM = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < NM[0]; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double horizontal = double.Parse(input[3]);
                double vertical = double.Parse(input[4]);

                Rectangle rectangle = new Rectangle(id, width, height, horizontal, vertical);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < NM[1]; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstId = input[0];
                string secondId = input[1];

                var check = CompareRectangles(rectangles, firstId, secondId);
                if (check)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        public static bool CompareRectangles(List<Rectangle> rectangles, string idFirstRectangle, string idSecondRectangle)
        {
            var rec1 = rectangles.FirstOrDefault(a => a.Id == idFirstRectangle);
            var rec2 = rectangles.FirstOrDefault(a => a.Id == idSecondRectangle);

            return rec1.Horizontal + rec1.Width >= rec2.Horizontal &&
                   rec1.Horizontal <= rec2.Horizontal + rec2.Width &&
                   rec1.Vertical >= rec2.Vertical - rec2.Height &&
                   rec1.Vertical - rec1.Height <= rec2.Vertical;
        }
    }
}

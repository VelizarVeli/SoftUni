using System;

namespace _04.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var height = int.Parse(Console.ReadLine());
            long[][] triangle = new long[height][];
            for (int counter = 0; counter < height; counter++)
            {
                triangle[counter]=new long[counter+1];
                triangle[counter][0] = 1;
                triangle[counter][counter] = 1;
                if (counter>=2)
                {
                    for (int widthCpunter = 1; widthCpunter < counter; widthCpunter++)
                    {
                        triangle[counter][widthCpunter] =
                            triangle[counter - 1][widthCpunter - 1] + triangle[counter - 1][widthCpunter];
                    }
                }
            }
            for (int rows = 0; rows < triangle.Length; rows++)
            {
                for (int columns = 0; columns < triangle[rows].Length; columns++)
                {
                    Console.Write($"{triangle[rows][columns]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

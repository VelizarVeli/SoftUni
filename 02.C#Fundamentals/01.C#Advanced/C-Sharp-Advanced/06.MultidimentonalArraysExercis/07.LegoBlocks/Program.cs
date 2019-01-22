using System;
using System.Linq;

namespace P07.LegoBlocks
{
    class LegoBlocks
    {
        static void Main()
        {
            int rowsNum = int.Parse(Console.ReadLine());

            int[][] leftBlock = new int[rowsNum][];
            int[][] rightBlock = new int[rowsNum][];

            for (int r = 0; r < rowsNum; r++)
            {
                leftBlock[r] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
            }

            for (int r = 0; r < rowsNum; r++)
            {
                rightBlock[r] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).Reverse().ToArray();
            }

            int rowLenght = leftBlock[0].Length + rightBlock[0].Length;
            int allElements = 0;
            bool isMatch = true;

            for (int r = 0; r < rowsNum; r++)
            {
                int currentLenght = leftBlock[r].Length + rightBlock[r].Length;
                if (currentLenght != rowLenght)
                {
                    isMatch = false;
                }

                allElements += currentLenght;
            }

            if (isMatch)
            {
                int[] resultRow = new int[rowLenght];
                for (int r = 0; r < rowsNum; r++)
                {
                    resultRow = leftBlock[r].Concat(rightBlock[r]).ToArray();
                    Console.WriteLine($"[{string.Join(", ", resultRow)}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {allElements}");
            }
        }
    }
}
using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rowsGalaxy = dimensions[0];
            int columnsGalaxy = dimensions[1];

            int[,] galaxy = new int[rowsGalaxy, columnsGalaxy];

            int value = 0;
            for (int row = 0; row < rowsGalaxy; row++)
            {
                for (int col = 0; col < columnsGalaxy; col++)
                {
                    galaxy[row, col] = value++;
                }
            }

            string command = Console.ReadLine();
            long valueSum = 0;
            while (command != "Let the Force be with you")
            {
                int[] inputIvo = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int rowEvil = evil[0];
                int colEvil = evil[1];

                while (rowEvil >= 0 && colEvil >= 0)
                {
                    if (rowEvil >= 0 && rowEvil < galaxy.GetLength(0) && colEvil >= 0 && colEvil < galaxy.GetLength(1))
                    {
                        galaxy[rowEvil, colEvil] = 0;
                    }
                    rowEvil--;
                    colEvil--;
                }

                int rowInputIvo = inputIvo[0];
                int colInputIvo = inputIvo[1];
                SummingGalaxies(galaxy, ref valueSum, ref rowInputIvo, ref colInputIvo);

                command = Console.ReadLine();
            }

            Console.WriteLine(valueSum);
        }

        private static void SummingGalaxies(int[,] galaxy, ref long valueSum, ref int rowInputIvo, ref int colInputIvo)
        {
            while (rowInputIvo >= 0 && colInputIvo < galaxy.GetLength(1))
            {
                if (rowInputIvo >= 0 && rowInputIvo < galaxy.GetLength(0) && colInputIvo >= 0 && colInputIvo < galaxy.GetLength(1))
                {
                    valueSum += galaxy[rowInputIvo, colInputIvo];
                }

                colInputIvo++;
                rowInputIvo--;
            }
        }
    }
}
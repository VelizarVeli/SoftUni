using System;
using System.Linq;

namespace RubiksMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var numberOfCommands = int.Parse(Console.ReadLine());
            var matrix = new int[sizes[0], sizes[1]];
            var bluePrint = new int[sizes[0], sizes[1]];
            var number = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = number++;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    bluePrint[i, j] = matrix[i, j];
                }
            }
            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandArgs = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var index = int.Parse(commandArgs[0]);
                var command = commandArgs[1];
                var distance = int.Parse(commandArgs[2]);
                if (command == "up" || command == "down")
                {
                    ShiftColumn(matrix, command, index, distance);
                }
                else if (command == "right" || command == "left")
                {
                    ShiftRow(matrix, command, index, distance);
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != bluePrint[i, j])
                    {
                        EqualizeValue(matrix, bluePrint, ref i, ref j);
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                }
            }
        }

        private static void EqualizeValue(int[,] matrix, int[,] bluePrint, ref int coordX, ref int coordY)
        {
            var swap = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == bluePrint[coordX, coordY])
                    {
                        Console.WriteLine($"Swap ({coordX}, {coordY}) with ({i}, {j})");
                        swap = matrix[coordX, coordY];
                        matrix[coordX, coordY] = matrix[i, j];
                        matrix[i, j] = swap;
                        return;
                    }
                }
            }
        }

        private static void ShiftRow(int[,] matrix, string command, int index, int distance)
        {
            var last = 0;
            if (command == "left")
            {
                for (int i = 0; i < distance % matrix.GetLength(1); i++)
                {
                    last = matrix[index, 0];
                    for (int j = 0, k = 1; j < matrix.GetLength(1) - 1; j++, k++)
                    {
                        matrix[index, j] = matrix[index, k];
                    }
                    matrix[index, matrix.GetLength(1) - 1] = last;
                }
            }
            else if (command == "right")
            {
                for (int i = 0; i < distance % matrix.GetLength(1); i++)
                {
                    last = matrix[index, matrix.GetLength(1) - 1];
                    for (int j = matrix.GetLength(1) - 1, k = matrix.GetLength(1) - 2; j >= 1; j--, k--)
                    {
                        matrix[index, j] = matrix[index, k];
                    }
                    matrix[index, 0] = last;
                }
            }
        }

        private static void ShiftColumn(int[,] matrix, string command, int index, int distance)
        {
            var last = 0;
            if (command == "down")
            {
                for (int i = 0; i < distance % matrix.GetLength(0); i++)
                {
                    last = matrix[matrix.GetLength(0) - 1, index];
                    for (int j = matrix.GetLength(0) - 1, k = matrix.GetLength(0) - 2; j >= 1; j--, k--)
                    {
                        matrix[j, index] = matrix[k, index];
                    }
                    matrix[0, index] = last;
                }
            }
            else if (command == "up")
            {
                for (int i = 0; i < distance % matrix.GetLength(0); i++)
                {
                    last = matrix[0, index];
                    for (int j = 0, k = 1; j < matrix.GetLength(0) - 1; j++, k++)
                    {
                        matrix[j, index] = matrix[k, index];
                    }
                    matrix[matrix.GetLength(0) - 1, index] = last;
                }
            }
        }
    }
}
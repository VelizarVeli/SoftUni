using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Crossfire
{
    static void Main()
    {
        int[] sizes = Console.ReadLine()
            .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        int rowSize = sizes[0];
        int colSize = sizes[1];

        int[][] matrix = FillMatrix(rowSize, colSize);

        string line;
        while ((line = Console.ReadLine()) != "Nuke it from orbit")
        {
            int[] bombTokens = line
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombRow = bombTokens[0];
            int bombCol = bombTokens[1];
            int bombRadius = bombTokens[2];

            Explosion(ref matrix, bombRow, bombCol, bombRadius);
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(" ", row.Where(n => n > 0)));
        }
    }

    private static void Explosion(ref int[][] matrix, int bombRow, int bombCol, int bombRadius)
    {
        //left and right
        for (int rowIndex = bombRow - bombRadius; rowIndex <= bombRow + bombRadius; rowIndex++)
        {
            if (AreIndexesValid(rowIndex, bombCol, matrix))
            {
                matrix[rowIndex][bombCol] = -1;
            }
        }

        //up and down
        for (int colIndex = bombCol - bombRadius; colIndex <= bombCol + bombRadius; colIndex++)
        {
            if (AreIndexesValid(bombRow, colIndex, matrix))
            {
                matrix[bombRow][colIndex] = -1;
            }
        }

        for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
        {
            if (matrix[rowIndex].Any(c => c == -1))
            {
                matrix[rowIndex] = matrix[rowIndex].Where(n => n > 0).ToArray();
            }

            if (matrix[rowIndex].Length < 1)
            {
                matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                rowIndex--;
            }
        }
    }

    private static bool AreIndexesValid(int row, int col, int[][] matrix)
    {
        return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
    }

    private static int[][] FillMatrix(int rowSize, int colSize)
    {
        int[][] matrix = new int[rowSize][];

        int fillNumber = 1;

        for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
        {
            matrix[rowIndex] = new int[colSize];
            for (int colIndex = 0; colIndex < colSize; colIndex++)
            {
                matrix[rowIndex][colIndex] = fillNumber;
                fillNumber++;
            }
        }

        return matrix;
    }
}
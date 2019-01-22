namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            string degreesString = Console.ReadLine().Trim().ToLower();

            Regex rg = new Regex(@"rotate\((\d+)\)");

            int degrees = int.Parse(rg.Match(degreesString).Groups[1].ToString());
            int rotationsCount = (degrees / 90) % 4;

            List<string> lines = new List<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                lines.Add(input);
                input = Console.ReadLine();
            }

            char[][] matrix = new char[lines.Count][];
            int wordsLen = lines.Max(r => r.Length);

            for (int row = 0; row < lines.Count; row++)
            {
                matrix[row] = lines[row].PadRight(wordsLen).ToCharArray();
            }

            for (int i = 0; i < rotationsCount; i++)
            {
                matrix = Rotate(matrix);
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static char[][] Rotate(char[][] words)
        {
            char[][] result = new char[words.Max(w => w.Length)][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[words.Length];

                for (int col = 0; col < result[row].Length; col++)
                {
                    result[row][col] = words[words.Length - 1 - col][row];
                }
            }

            return result;
        }
    }
}
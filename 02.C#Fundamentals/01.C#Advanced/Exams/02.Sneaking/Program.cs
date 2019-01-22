using System;

namespace _02.Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            char[] M = Console.ReadLine().ToCharArray();
            char[,] room = new char[N, M.Length];
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < M.Length; col++)
                {
                    room[row, col] = M[col];
                }
                M = Console.ReadLine().ToCharArray();
            }
        }
    }
}

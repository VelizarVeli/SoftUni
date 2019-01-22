using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] checkBoard = new string[8, 8];
            for (int row = 0; row < 8; row++)
            {
                string[] input = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < 8; col++)
                {
                    checkBoard[row, col] = input[col];
                }
            }
            string[] commands = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (commands[0] != "END")
            {
                string figure = commands[0].Substring(0, 1);
                int rowCurrentPosition = int.Parse(commands[0].Substring(1, 1));
                int columnCurrentPosition = int.Parse(commands[0].Substring(2, 1));
                int rowMovingPosition = int.Parse(commands[1].Substring(0, 1));
                int columnMovingPosition = int.Parse(commands[1].Substring(1, 1));

                if (figure != checkBoard[rowCurrentPosition, columnCurrentPosition])
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (rowMovingPosition > 7 || rowMovingPosition < 0 || columnMovingPosition > 7 || columnMovingPosition < 0)
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {

                    if (figure == "K")
                    {
                        List<string> kingMoves = new List<string>();

                        int rowMinus = rowCurrentPosition - 1;
                        int rowPlus = rowCurrentPosition + 1;
                        int colMinus = columnCurrentPosition - 1;
                        int colPlus = columnCurrentPosition + 1;

                        string rowMinuss = rowMinus.ToString();
                        string rows = rowCurrentPosition.ToString();
                        string rowPluss = rowPlus.ToString();
                        string colMinuss = colMinus.ToString();
                        string cols = columnCurrentPosition.ToString();
                        string colPluss = colPlus.ToString();


                        string middleRight = rows + colPluss;
                        kingMoves.Add(middleRight);
                        string bottomRight = rowPluss + colPluss;
                        kingMoves.Add(bottomRight);
                        string bottomMiddle = rowPluss + cols;
                        kingMoves.Add(bottomMiddle);
                        string bottomLeft = rowPluss + colMinuss;
                        kingMoves.Add(bottomLeft);
                        string middleLeft = rows + colMinuss;
                        kingMoves.Add(middleLeft);
                        string leftUp = rowMinuss + colMinuss;
                        kingMoves.Add(leftUp);
                        string middleUp = rowMinuss + cols;
                        kingMoves.Add(middleUp);
                        string rightUp = rowMinuss + colPluss;
                        kingMoves.Add(rightUp);

                        string movingTo = commands[1];
                        if (!kingMoves.Contains(movingTo))
                        {
                            Console.WriteLine("Invalid move!");
                        }
                        else
                        {
                            checkBoard[rowCurrentPosition, columnCurrentPosition] = "x";
                            checkBoard[rowMovingPosition, columnMovingPosition] = "K";
                        }
                    }
                    else if (figure == "R")
                    {
                        List<string> moves = new List<string>();
                        for (int row = 0; row < 8; row++)
                        {
                            for (int col = 0; col < 8; col++)
                            {
                                if (row == rowCurrentPosition || col == columnCurrentPosition)
                                {
                                    string ro = row.ToString();
                                    string co = col.ToString();
                                    string roco = ro + co;
                                    moves.Add(roco);
                                }
                            }
                        }
                        string ros = rowCurrentPosition.ToString();
                        string cos = columnCurrentPosition.ToString();
                        string rosCos = ros + cos;
                        moves.Remove(rosCos);
                        string roso = rowMovingPosition.ToString();
                        string coso = columnMovingPosition.ToString();
                        string rosoCoso = roso + coso;
                        if (!moves.Contains(rosoCoso))
                        {
                            Console.WriteLine("Invalid move!");
                        }
                        else
                        {
                            checkBoard[rowCurrentPosition, columnCurrentPosition] = "x";
                            checkBoard[rowMovingPosition, columnMovingPosition] = "R";
                        }
                    }
                    else if (figure == "B")
                    {
                        List<string> bishopMoves = new List<string>();
                        int row = rowCurrentPosition + 1;
                        int col = columnCurrentPosition + 1;
                        for (int i = rowCurrentPosition; i < 7; i++)
                        {
                            string rowS = row.ToString();
                            string colS = col.ToString();
                            string rowSColS = rowS + colS;
                            bishopMoves.Add(rowSColS);
                            row++;
                            col++;
                        }
                        int row1 = rowCurrentPosition + 1;
                        int col1 = columnCurrentPosition - 1;
                        for (int j = 0; j < columnCurrentPosition; j++)
                        {
                            string rowS = row1.ToString();
                            string colS = col1.ToString();
                            string rowSColS = rowS + colS;
                            bishopMoves.Add(rowSColS);
                            row1++;
                            col1--;
                        }
                        int row2 = rowCurrentPosition - 1;
                        int col2 = columnCurrentPosition + 1;
                        for (int k = rowCurrentPosition; row2 >= 0; k++)
                        {
                            string rowS = row2.ToString();
                            string colS = col2.ToString();
                            string rowSColS = rowS + colS;
                            bishopMoves.Add(rowSColS);
                            row2--;
                            col2++;
                        }
                        int row3 = rowCurrentPosition - 1;
                        int col3 = columnCurrentPosition - 1;
                        for (int k = rowCurrentPosition; col3 >= 0; k++)
                        {
                            string rowS = row3.ToString();
                            string colS = col3.ToString();
                            string rowSColS = rowS + colS;
                            bishopMoves.Add(rowSColS);
                            row3--;
                            col3--;
                        }
                        string roso = rowMovingPosition.ToString();
                        string coso = columnMovingPosition.ToString();
                        string rosoCoso = roso + coso;
                        if (!bishopMoves.Contains(rosoCoso))
                        {
                            Console.WriteLine("Invalid move!");
                        }
                        else
                        {
                            checkBoard[rowCurrentPosition, columnCurrentPosition] = "x";
                            checkBoard[rowMovingPosition, columnMovingPosition] = "B";
                        }
                    }
                    else if (figure == "Q")
                    {
                        List<string> queenMoves = new List<string>();
                        int row = rowCurrentPosition + 1;
                        int col = columnCurrentPosition + 1;
                        for (int i = rowCurrentPosition; i < 7; i++)
                        {
                            string rowS = row.ToString();
                            string colS = col.ToString();
                            string rowSColS = rowS + colS;
                            queenMoves.Add(rowSColS);
                            row++;
                            col++;
                        }
                        int row1 = rowCurrentPosition + 1;
                        int col1 = columnCurrentPosition - 1;
                        for (int j = 0; j < columnCurrentPosition; j++)
                        {
                            string rowS = row1.ToString();
                            string colS = col1.ToString();
                            string rowSColS = rowS + colS;
                            queenMoves.Add(rowSColS);
                            row1++;
                            col1--;
                        }
                        int row2 = rowCurrentPosition - 1;
                        int col2 = columnCurrentPosition + 1;
                        for (int k = rowCurrentPosition; row2 >= 0; k++)
                        {
                            string rowS = row2.ToString();
                            string colS = col2.ToString();
                            string rowSColS = rowS + colS;
                            queenMoves.Add(rowSColS);
                            row2--;
                            col2++;
                        }
                        int row3 = rowCurrentPosition - 1;
                        int col3 = columnCurrentPosition - 1;
                        for (int k = rowCurrentPosition; col3 >= 0; k++)
                        {
                            string rowS = row3.ToString();
                            string colS = col3.ToString();
                            string rowSColS = rowS + colS;
                            queenMoves.Add(rowSColS);
                            row3--;
                            col3--;
                        }
                       
                        for (int row4 = 0; row4 < 8; row4++)
                        {
                            for (int col4 = 0; col4 < 8; col4++)
                            {
                                if (row4 == rowCurrentPosition || col4 == columnCurrentPosition)
                                {
                                    string ro = row4.ToString();
                                    string co = col4.ToString();
                                    string roco = ro + co;
                                    queenMoves.Add(roco);
                                }
                            }
                        }
                        string ros = rowCurrentPosition.ToString();
                        string cos = columnCurrentPosition.ToString();
                        string rosCos = ros + cos;
                        queenMoves.Remove(rosCos);
                        string roso4 = rowMovingPosition.ToString();
                        string coso4 = columnMovingPosition.ToString();
                        string rosoCoso4 = roso4 + coso4;
                        if (!queenMoves.Contains(rosoCoso4))
                        {
                            Console.WriteLine("Invalid move!");
                        }
                        else
                        {
                            checkBoard[rowCurrentPosition, columnCurrentPosition] = "x";
                            checkBoard[rowMovingPosition, columnMovingPosition] = "Q";
                        }
                    }
                    else if (figure == "P")
                    {
                        if (rowCurrentPosition - 1 != rowMovingPosition)
                        {
                            Console.WriteLine("Invalid move!");
                        }
                        else
                        {
                            checkBoard[rowCurrentPosition, columnCurrentPosition] = "x";
                            checkBoard[rowMovingPosition, columnMovingPosition] = "P";
                        }
                    }
                    
                }

                commands = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
    }
}

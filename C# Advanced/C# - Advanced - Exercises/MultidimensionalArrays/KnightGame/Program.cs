using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[n, n];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] currRow = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currRow[col];
                }
            }
            int counter = 0;

            while (true)
            {
                int maxCount = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        int knightsCount = 0;
                        if (chessBoard[row, col] == 'K')
                        {
                            //1
                            if (IsInside(chessBoard, row - 2, col + 1)
                                && chessBoard[row - 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }
                            //2
                            if (IsInside(chessBoard, row - 2, col - 1)
                                && chessBoard[row - 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }
                            //3
                            if (IsInside(chessBoard, row + 2, col + 1)
                                && chessBoard[row + 2, col + 1] == 'K')
                            {
                                knightsCount++;
                            }
                            //4
                            if (IsInside(chessBoard, row + 2, col - 1)
                                && chessBoard[row + 2, col - 1] == 'K')
                            {
                                knightsCount++;
                            }
                            //5
                            if (IsInside(chessBoard, row - 1, col - 2)
                                && chessBoard[row - 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }
                            //6
                            if (IsInside(chessBoard, row - 1, col + 2)
                                && chessBoard[row - 1, col + 2] == 'K')
                            {
                                knightsCount++;
                            }
                            //7
                            if (IsInside(chessBoard, row + 1, col - 2)
                                && chessBoard[row + 1, col - 2] == 'K')
                            {
                                knightsCount++;
                            }
                            //8
                            if (IsInside(chessBoard, row + 1, col + 2)
                                && chessBoard[row + 1, col + 2] == 'K')
                            {
                                knightsCount++;

                            }
                        }
                        if (knightsCount > maxCount)
                        {
                            maxCount = knightsCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }
                if (maxCount == 0)
                {
                    break;
                }
                chessBoard[knightRow, knightCol] = '0';
                counter++;
            }
            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] chessBoard, int desiredRow, int desiredCol)
        {
            return desiredRow >= 0 && desiredRow < chessBoard.GetLength(0)
                && desiredCol >= 0 && desiredCol < chessBoard.GetLength(1);
        }
    }
}

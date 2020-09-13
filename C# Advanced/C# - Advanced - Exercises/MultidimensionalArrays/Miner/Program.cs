using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            char[,] field = new char[size, size];
            int coalsCount = 0;
            int currRow = -1;
            int currCol = -1;
            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] currRowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = currRowInput[col];
                    if (field[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                    else if (field[row, col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            int rowIndex = currRow;
            int colIndex = currCol;
            bool isOver = false;
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i] == "up")
                {
                    if (currRow >= 1 && currRow < field.GetLength(0))
                    {
                        int nextRow = --currRow;
                        if (nextRow >= 0 && nextRow < field.GetLength(0) &&
                            field[nextRow, currCol] == 'c')
                        {
                            coalsCount--;
                            field[nextRow, currCol] = '*';
                        }
                        else if (nextRow >= 0 && nextRow < field.GetLength(0) &&
                            field[nextRow, currCol] == 'e')
                        {
                            isOver = true;
                            rowIndex = nextRow;
                            colIndex = currCol;
                            break;
                        }
                        currRow = nextRow;
                    }
                }
                else if (commands[i] == "down")
                {
                    if (currRow >= 0 && currRow < field.GetLength(0) - 1)
                    {
                        int nextRow = ++currRow;
                        if (nextRow >= 1 && nextRow < field.GetLength(0) &&
                            field[nextRow, currCol] == 'c')
                        {
                            coalsCount--;
                            field[nextRow, currCol] = '*';
                        }
                        else if (nextRow >= 1 && nextRow < field.GetLength(0) &&
                            field[nextRow, currCol] == 'e')
                        {
                            isOver = true;
                            rowIndex = nextRow;
                            colIndex = currCol;
                            break;
                        }
                        currRow = nextRow;
                    }
                }
                else if (commands[i] == "left")
                {
                    if (currCol >= 1 && currCol < field.GetLength(1))
                    {
                        int nextCol = --currCol;
                        if (nextCol >= 0 && nextCol < field.GetLength(1) - 1 &&
                            field[currRow, nextCol] == 'c')
                        {
                            coalsCount--;
                            field[currRow, nextCol] = '*';
                        }
                        else if (nextCol >= 0 && nextCol < field.GetLength(1) - 1 &&
                            field[currRow, nextCol] == 'e')
                        {
                            isOver = true;
                            rowIndex = currRow;
                            colIndex = nextCol;
                            break;
                        }
                        currCol = nextCol;
                    }

                }
                else if (commands[i] == "right")
                {
                    if (currCol >= 0 && currCol < field.GetLength(1) - 1)
                    {
                        int nextCol = ++currCol;
                        if (nextCol >= 1 && nextCol < field.GetLength(1) &&
                            field[currRow, nextCol] == 'c')
                        {
                            coalsCount--;
                            field[currRow, nextCol] = '*';
                        }
                        else if (nextCol >= 1 && nextCol < field.GetLength(1) &&
                            field[currRow, nextCol] == 'e')
                        {
                            isOver = true;
                            rowIndex = currRow;
                            colIndex = nextCol;
                            break;
                        }
                        currCol = nextCol;
                    }

                }
            }
            if (isOver)
            {
                Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
            }
            else
            {
                if (coalsCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");
                }
                else if (coalsCount > 0)
                {
                    Console.WriteLine($"{coalsCount} coals left. ({currRow}, {currCol})");
                }
            }

        }
    }
}

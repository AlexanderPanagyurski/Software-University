using System;
using System.Collections.Generic;

namespace SpaceStationEstablishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[][] galaxy = new char[size][];
            int currRow = -1;
            int currCol = -1;
            int energy = 0;
            int secondBlackHoleRow = -1;
            int secondBlackHoleCol = -1;

            for (int row = 0; row < galaxy.Length; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                galaxy[row] = input;
                for (int col = 0; col < galaxy[row].Length; col++)
                {

                    if (galaxy[row][col] == 'S')
                    {
                        currRow = row;
                        currCol = col;
                    }
                    else if (galaxy[row][col] == 'O')
                    {
                        secondBlackHoleRow = row;
                        secondBlackHoleCol = col;
                    }
                }
            }

            while (true)
            {
                string currCommand = Console.ReadLine().ToLower();
                if (currCommand == "up")
                {
                    if (currRow - 1 >= 0 && currRow < galaxy.Length
                        && galaxy[currRow - 1][currCol] == '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        --currRow;
                        galaxy[currRow][currCol] = 'S';
                    }
                    else if (currRow - 1 >= 0 && currRow < galaxy.Length
                        && galaxy[currRow - 1][currCol] == 'O')
                    {
                        galaxy[currRow][currCol] = '-';
                        galaxy[currRow - 1][currCol] = '-';
                        galaxy[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        currRow = secondBlackHoleRow;
                        currCol = secondBlackHoleCol;
                    }
                    else if (currRow - 1 >= 0 && currRow < galaxy.Length
                        && galaxy[currRow - 1][currCol] != 'O' && galaxy[currRow - 1][currCol] != '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        --currRow;
                        string NumberAsStr = galaxy[currRow][currCol].ToString();
                        galaxy[currRow][currCol] = 'S';
                        int energyPoints = int.Parse(NumberAsStr);
                        energy += energyPoints;
                        if (energy >= 50)
                        {
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            break;
                        }
                    }
                    else if (currRow - 1 < 0)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        galaxy[currRow][currCol] = '-';
                        break;
                    }
                }
                else if (currCommand == "down")
                {
                    if (currRow + 1 >= 1 && currRow < galaxy.Length
                        && galaxy[currRow + 1][currCol] == '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        ++currRow;
                        galaxy[currRow][currCol] = 'S';
                    }
                    else if (currRow + 1 >= 0 && currRow < galaxy.Length
                        && galaxy[currRow + 1][currCol] == 'O')
                    {
                        galaxy[currRow][currCol] = '-';
                        galaxy[currRow + 1][currCol] = '-';
                        galaxy[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        currRow = secondBlackHoleRow;
                        currCol = secondBlackHoleCol;
                    }
                    else if (currRow + 1 >= 0 && currRow < galaxy.Length
                        && galaxy[currRow + 1][currCol] != 'O' && galaxy[currRow + 1][currCol] != '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        ++currRow;
                        string NumberAsStr = galaxy[currRow][currCol].ToString();
                        galaxy[currRow][currCol] = 'S';
                        int energyPoints = int.Parse(NumberAsStr);
                        energy += energyPoints;
                        if (energy >= 50)
                        {
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            break;
                        }
                    }
                    else if (currRow + 1 >= galaxy.Length)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        galaxy[currRow][currCol] = '-';
                        break;
                    }
                }
                else if (currCommand == "left")
                {
                    if (currCol - 1 >= 0 && currCol - 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol - 1] == '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        --currCol;
                        galaxy[currRow][currCol] = 'S';
                    }
                    else if (currCol - 1 >= 0 && currCol - 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol - 1] == 'O')
                    {
                        galaxy[currRow][currCol] = '-';
                        galaxy[currRow][currCol - 1] = '-';
                        galaxy[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        currRow = secondBlackHoleRow;
                        currCol = secondBlackHoleCol;
                    }
                    else if (currCol - 1 >= 0 && currCol - 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol - 1] != 'O' && galaxy[currRow][currCol - 1] != '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        --currCol;
                        string NumberAsStr = galaxy[currRow][currCol].ToString();
                        galaxy[currRow][currCol] = 'S';
                        int energyPoints = int.Parse(NumberAsStr);
                        energy += energyPoints;
                        if (energy >= 50)
                        {
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            break;
                        }
                    }
                    else if (currCol - 1 < 0)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        galaxy[currRow][currCol] = '-';
                        break;
                    }
                }
                else if (currCommand == "right")
                {
                    if (currCol + 1 >= 1 && currCol + 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol + 1] == '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        ++currCol;
                        galaxy[currRow][currCol] = 'S';
                    }
                    else if (currCol + 1 >= 1 && currCol + 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol + 1] == 'O')
                    {
                        galaxy[currRow][currCol] = '-';
                        galaxy[currRow][currCol + 1] = '-';
                        galaxy[secondBlackHoleRow][secondBlackHoleCol] = 'S';
                        currRow = secondBlackHoleRow;
                        currCol = secondBlackHoleCol;
                    }
                    else if (currCol + 1 >= 0 && currCol + 1 < galaxy[currRow].Length
                        && galaxy[currRow][currCol + 1] != 'O' && galaxy[currRow][currCol + 1] != '-')
                    {
                        galaxy[currRow][currCol] = '-';
                        ++currCol;
                        string NumberAsStr = galaxy[currRow][currCol].ToString();
                        galaxy[currRow][currCol] = 'S';
                        int energyPoints = int.Parse(NumberAsStr);
                        energy += energyPoints;
                        if (energy >= 50)
                        {
                            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                            break;
                        }
                    }
                    else if (currCol + 1 >= galaxy[currRow].Length)
                    {
                        Console.WriteLine("Bad news, the spaceship went to the void.");
                        galaxy[currRow][currCol] = '-';
                        break;
                    }
                }
            }
            Console.WriteLine($"Star power collected: {energy}");

            for (int row = 0; row < galaxy.Length; row++)
            {
                for (int col = 0; col < galaxy[row].Length; col++)
                {
                    Console.Write(galaxy[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}

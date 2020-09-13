using System;
using System.Collections.Generic;
using System.Linq;

namespace TheGarden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            char[][] garden = new char[rowsCount][];
            var vegetablesDictionary = new Dictionary<string, int>();
            vegetablesDictionary.Add("Lettuce", 0);
            vegetablesDictionary.Add("Potatoes", 0);
            vegetablesDictionary.Add("Carrots", 0);
            vegetablesDictionary.Add("Harmed vegetables", 0);

            for (int i = 0; i < garden.Length; i++)
            {
                char[] vegetables = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                garden[i] = new char[vegetables.Length];

                for (int j = 0; j < garden[i].Length; j++)
                {
                    garden[i][j] = vegetables[j];
                }
            }
            //Console.WriteLine();

            string command = Console.ReadLine().ToLower();

            while (command != "end of harvest")
            {
                var splitCommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (splitCommand[0] == "harvest")
                {
                    int row = int.Parse(splitCommand[1]);
                    int col = int.Parse(splitCommand[2]);

                    if (row >= 0 && row < garden.Length
                        && col >= 0 && col < garden[row].Length
                        && garden[row][col] != ' ')
                    {
                        if (garden[row][col] == 'L')
                        {
                            vegetablesDictionary["Lettuce"]++;
                        }
                        else if (garden[row][col] == 'P')
                        {
                            vegetablesDictionary["Potatoes"]++;
                        }
                        else if (garden[row][col] == 'C')
                        {
                            vegetablesDictionary["Carrots"]++;
                        }
                        garden[row][col] = ' ';
                    }
                }
                else if (splitCommand[0] == "mole")
                {
                    int row = int.Parse(splitCommand[1]);
                    int col = int.Parse(splitCommand[2]);
                    string direction = splitCommand[3].ToLower();

                    if (direction == "up"
                        && row >= 0 && row < garden.Length
                        && col >= 0 && col < garden[row].Length
                        && garden[row][col] != ' ')
                    {
                        for (int i = row; i >= 0; i -= 2)
                        {
                            if (garden[i][col] != ' ')
                            {
                                vegetablesDictionary["Harmed vegetables"]++;
                                garden[i][col] = ' ';
                            }
                        }
                    }
                    else if (direction == "down"
                            && row >= 0 && row < garden.Length
                            && col >= 0 && col < garden[row].Length
                            && garden[row][col] != ' ')
                    {
                        for (int i = row; i < garden.Length; i += 2)
                        {
                            if (garden[i][col] != ' ')
                            {
                                vegetablesDictionary["Harmed vegetables"]++;
                                garden[i][col] = ' ';
                            }
                        }
                    }
                    else if (direction == "right"
                        && row >= 0 && row < garden.Length
                        && col >= 0 && col < garden[row].Length
                        && garden[row][col] != ' ')
                    {
                        for (int i = col; i < garden[row].Length; i += 2)
                        {
                            if (garden[row][i] != ' ')
                            {
                                vegetablesDictionary["Harmed vegetables"]++;
                                garden[row][i] = ' ';
                            }
                        }
                    }
                    else if (direction == "left"
                        && row >= 0 && row < garden.Length
                        && col >= 0 && col < garden[row].Length
                        && garden[row][col] != ' ')
                    {

                        for (int i = garden[row].Length - (garden[row].Length - col); i >= 0; i -= 2)
                        {
                            if (garden[row][i] != ' ')
                            {
                                vegetablesDictionary["Harmed vegetables"]++;
                                garden[row][i] = ' ';
                            }
                        }
                    }

                }
                command = Console.ReadLine().ToLower();
            }
            for (int i = 0; i < garden.Length; i++)
            {
                for (int j = 0; j < garden[i].Length; j++)
                {
                    Console.Write(garden[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Carrots: {vegetablesDictionary["Carrots"]}");
            Console.WriteLine($"Potatoes: {vegetablesDictionary["Potatoes"]}");
            Console.WriteLine($"Lettuce: {vegetablesDictionary["Lettuce"]}");
            Console.WriteLine($"Harmed vegetables: {vegetablesDictionary["Harmed vegetables"]}");
        }
    }
}
using System;
using System.Collections.Generic;

namespace HotPotatoe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count =int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            string command = Console.ReadLine();
            int counter = 0;

            while (command != "end")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    if (queue.Count>0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            counter++;
                            if (queue.Count == 0)
                            {
                                break;
                            }
                        }
                    }
                }
                command =Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}

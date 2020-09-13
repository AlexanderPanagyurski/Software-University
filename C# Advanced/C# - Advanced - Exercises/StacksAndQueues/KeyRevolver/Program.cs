using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            Stack<int> stackOfBullets = new Stack<int>(bullets);
            Stack<int> stackOfLocks = new Stack<int>(locks.Reverse());
            int barrelCounter = 0;
            int bulletsCount = 0;

            while (stackOfBullets.Count > 0 && stackOfLocks.Count > 0)
            {
                int currentBullet = stackOfBullets.Pop();
                int currentLock = stackOfLocks.Peek();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    stackOfLocks.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                barrelCounter++;
                bulletsCount++;
                if (barrelCounter % gunBarrelSize == 0 && stackOfBullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            bulletsCount *= pricePerBullet;
            if (stackOfLocks.Count > stackOfBullets.Count)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {stackOfLocks.Count}");
            }
            else
            {
                Console.WriteLine($"{stackOfBullets.Count} bullets left. Earned ${valueOfIntelligence - bulletsCount}");
            }
        }
    }
}

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bull = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] locky = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int intelligenceVallue = int.Parse(Console.ReadLine());
            int bulletSum = 0;
            int currentNumBullets = gunBarrelSize;
            Stack<int> bullets = new Stack<int>();
            for (int i = 0; i < bull.Length; i++)
            {
                bullets.Push(bull[i]);
            }
            Queue<int> locks = new Queue<int>();
            for (int j = 0; j < locky.Length; j++)
            {
                locks.Enqueue(locky[j]);
            }
            while (true)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();
                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                    currentNumBullets--;
                    bulletSum += bulletPrice;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    currentNumBullets--;
                    bulletSum += bulletPrice;
                }
                if (currentNumBullets == 0)
                {
                    if (bullets.Count != 0)
                    {
                        Console.WriteLine("Reloading!");
                        currentNumBullets = gunBarrelSize;
                    }
                }
                if (locks.Count == 0)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceVallue - bulletSum}");
                    break;
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}

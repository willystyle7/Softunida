using System;
using System.Collections.Generic;
using System.Linq;

namespace SumNto13
{
    class Program
    {
        static void Main()
        {
            int n = 3;
            int controlSum = 13;

            //string[] input = Console.ReadLine().Split(' ');
            //int[] number = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    number[i] = int.Parse(input[i]);
            //}

            var number = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(number[0]);
            queue.Enqueue(-number[0]);
            for (int i = 1; i < n; i++)
            {
                int currentCount = queue.Count;
                for (int j = 0; j < currentCount; j++)
                {
                    int outQueue = queue.Dequeue();
                    queue.Enqueue(outQueue + number[i]);
                    queue.Enqueue(outQueue - number[i]);
                }
            }
            Console.WriteLine(queue.Contains(controlSum) ? "Yes" : "No");
        }
    }
}

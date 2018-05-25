using System;
using System.Collections.Generic;

namespace BingoGenerator
{
    class BingoGenerator
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int number1 = (number / 1000) * 10 + (number / 10) % 10;
            int number2 = ((number / 100) % 10) * 10 + number % 10;
            int limitNumber = number1 + number2;
            List<int> numsDiv12 = new List<int>();
            List<int> numsDiv15 = new List<int>();
            for (int i = number1; i <= limitNumber; i++)
            {
                for (int j = number2; j <= limitNumber; j++)
                {
                    int currentNum = i * 100 + j;
                    if (currentNum % 12 == 0)
                    {
                        numsDiv12.Add(currentNum);
                    }
                    if (currentNum % 15 == 0)
                    {
                        numsDiv15.Add(currentNum);
                    }
                }
            }
            Console.WriteLine("Dividing on 12: {0}", string.Join(" ", numsDiv12));
            Console.WriteLine("Dividing on 15: {0}", string.Join(" ", numsDiv15));
            Console.WriteLine((numsDiv12.Count == numsDiv15.Count) ? "!!!BINGO!!!" : "NO BINGO!");
        }
    }
}

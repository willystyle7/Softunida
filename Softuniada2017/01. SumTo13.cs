using System;

namespace SumTo13
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            if ((a + b + c == 13) || (a + b - c == 13) || (a - b + c == 13) || (a - b - c == 13)
                 || (-a + b + c == 13) || (-a + b - c == 13) || (-a - b - c == 13) || (-a - b + c == 13)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}

using System;

class DrawHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(new string('.', n - 1) + "*" + new string('.', n - 1));
        for (int i = 1; i <= n - 2; i++)
        {
            Console.WriteLine(new string('.', n - 1 - i) + "*" + new string(' ', 2 * i - 1) + "*" + new string('.', n - 1 - i));
        }
        for (int i = 1; i < n; i++)
        {
            Console.Write("* ");
        }
        Console.Write("*"); Console.WriteLine();
        Console.WriteLine("+" + new string('-', 2 * n - 3) + "+");
        for (int i = 1; i <= n - 2; i++)
        {
            Console.WriteLine("|" + new string(' ', 2 * n - 3) + "|");
        }
        Console.WriteLine("+" + new string('-', 2 * n - 3) + "+");
    }
}

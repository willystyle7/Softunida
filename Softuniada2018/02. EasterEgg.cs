using System;

namespace EasterEgg
{
    class EasterEgg
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('.', 2 * n) + new string('*', n) + new string('.', 2 * n));
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine(new string('.', 2 * (n - i)) + new string('*', i) + new string('+', n + 2 * i) + new string('*', i) + new string('.', 2 * (n - i)));
            }
            for (int i = 1; i <= n / 2; i++)
            {
                Console.WriteLine(new string('.', n - i) + "**" + new string('=', 3 * n + 2 * i - 4) + "**" + new string('.', n - i));
            }
            Console.WriteLine(new string('.', n / 2) + "**" + new string('~', 2 * n - 8) + "HAPPY EASTER" + new string('~', 2 * n - 8) + "**" + new string('.', n / 2));
            for (int i = n / 2; i >= 1; i--)
            {
                Console.WriteLine(new string('.', n - i) + "**" + new string('=', 3 * n + 2 * i - 4) + "**" + new string('.', n - i));

            }
            for (int i = n / 2; i >= 1; i--)
            {
                Console.WriteLine(new string('.', 2 * (n - i)) + new string('*', i) + new string('+', n + 2 * i) + new string('*', i) + new string('.', 2 * (n - i)));

            }
            Console.WriteLine(new string('.', 2 * n) + new string('*', n) + new string('.', 2 * n));
        }
    }
}
using System;

namespace HalloweenPumpkin
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('.', n - 1) + "_/_" + new string('.', n - 1));
            Console.WriteLine("/" + new string('.', n - 2) + "^,^" + new string('.', n - 2) + "\\");
            for (int i = 0; i < n - 3; i++)
            {
                Console.WriteLine("|" + new string('.', 2 * n - 1) + "|");
            }
            Console.WriteLine("\\" + new string('.', n - 2) + "\\_/" + new string('.', n - 2) + "/");
        }
    }
}

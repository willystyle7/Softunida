namespace DreamCar
{
    using System;
    using System.Diagnostics;

    public static class Program
    {
        public static void Main()
        {
            var n = double.Parse(Console.ReadLine());
            var m = double.Parse(Console.ReadLine());
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            var t = uint.Parse(Console.ReadLine());

            var isEnough = IsEnough(n, m, x, y, t);
            Console.WriteLine(isEnough ? "Have a nice ride!" : "Work harder!");
        }

        public static bool IsEnough(double n, double m, double x, double y, uint t)
        {
            var savings = t * ((2 * (n - m)) + ((t - 1) * x)) / 2;
            Debug.WriteLine($"Saved: {savings}");
            return y <= savings;
        }
    }
}
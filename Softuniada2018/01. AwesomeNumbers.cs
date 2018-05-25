using System;

namespace AwesomeNumbers
{
    class AwesomeNumbers
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int favourite = int.Parse(Console.ReadLine());
            bool condition1 = number < 0;
            bool condition2 = Math.Abs(number) % 2 == 1;
            bool condition3 = (favourite == 0) ? false : (number % favourite == 0);
            if (condition1 && condition2 && condition3)
            {
                Console.WriteLine("super special awesome");
            }
            else if ((condition1 && condition2)
                || (condition1 && condition3)
                || (condition2 && condition3))
            {
                Console.WriteLine("super awesome");
            }
            else if (condition1 || condition2 || condition3)
            {
                Console.WriteLine("awesome");
            }
            else
            {
                Console.WriteLine("boring");
            }
        }
    }
}
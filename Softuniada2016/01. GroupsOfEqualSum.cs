using System;

namespace GroupsOfEqualSum
{
    class GroupsOfEqualSum
    {
        static void Main()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            int n4 = int.Parse(Console.ReadLine());
            if (n1 == n2 + n3 + n4)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n1);
            }
            else if (n1 + n2 == n3 + n4)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n1 + n2);
            }
            else if (n1 + n3 == n2 + n4)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n1 + n3);
            }
            else if (n1 + n4 == n2 + n3)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n1 + n4);
            }
            else if (n1 + n2 + n3 == n4)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n4);
            }
            else if (n1 + n2 + n4 == n3)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n3);
            }
            else if (n1 + n3 + n4 == n2)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(n2);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
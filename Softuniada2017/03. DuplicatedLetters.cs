using System;

namespace DuplicatedLetters
{
    class Program
    {
        static void Main()
        {
            string str = Console.ReadLine();
            int count = 0;
            bool operation = true;
            while (operation)
            {
                operation = false;
                for (int i = 0; i < str.Length - 1; i++)
                {
                    if (str[i] == str[i + 1])
                    {
                        str = str.Remove(i, 2);
                        count++;
                        operation = true;
                        break;
                    }
                }
            }
            Console.WriteLine("{0}", (str.Length == 0) ? ("Empty String\n" + count + " operations") : (str + "\n" + count + " operations"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lumber
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            int numberLumbers = int.Parse(input[0]);
            int numberQueries = int.Parse(input[1]);
            List<Lumber> lumbers = new List<Lumber>();
            int[] id = new int[numberLumbers];
            for (int i = 0; i < numberLumbers; i++)
            {
                id[i] = i;
            }
            for (int i = 0; i < numberLumbers; i++)
            {
                int[] token = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Lumber lumber = new Lumber();
                lumber.AX = token[0];
                lumber.AY = token[1];
                lumber.BX = token[2];
                lumber.BY = token[3];
                lumbers.Add(lumber);
                for (int j = 0; j < i; j++)
                {
                    if (LumbersIntersect(lumbers[j], lumber))
                    {
                        int t = id[i];
                        for (int k = 0; k < numberLumbers; k++)
                        {
                            if (id[k] == t)
                            {
                                id[k] = id[j];
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < numberQueries; i++)
            {
                int[] token = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstLumber = token[0] - 1;
                int secondLumber = token[1] - 1;
                Console.WriteLine((id[firstLumber] == id[secondLumber]) ? "YES" : "NO");
            }
        }

        static bool LumbersIntersect(Lumber lumber1, Lumber lumber2)
        {
            bool areIntercepted = true;            
            if (lumber1.AX > lumber2.BX || lumber1.BX < lumber2.AX || lumber1.AY < lumber2.BY || lumber1.BY > lumber2.AY)
            {
                areIntercepted = false;
            }
            return areIntercepted;
        }
    }

    class Lumber
    {
        public int AX { get; set; }
        public int AY { get; set; }
        public int BX { get; set; }
        public int BY { get; set; }
    }
}

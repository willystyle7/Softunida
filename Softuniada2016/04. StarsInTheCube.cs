using System;
using System.Collections.Generic;
using System.Linq;

namespace StarsInTheCube
{
    class StarsInTheCube
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,,] cube = new char[n, n, n];
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < n; layer++)
                {
                    char[] token = input[layer].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => x[0]).ToArray();
                    for (int column = 0; column < n; column++)
                    {
                        cube[layer, row, column] = token[column];
                    }
                }
            }
            Dictionary<char, int> starsBySymbol = new Dictionary<char, int>();
            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    for (int k = 1; k < n - 1; k++)
                    {
                        if (IsStarCenter(cube, i, j, k))
                        {
                            if (!starsBySymbol.ContainsKey(cube[i, j, k]))
                            {
                                starsBySymbol.Add(cube[i, j, k], 0);
                            }
                            starsBySymbol[cube[i, j, k]]++;
                        }
                    }
                }
            }
            int allStars = starsBySymbol.Values.Sum();
            Console.WriteLine(allStars);
            foreach (var star in starsBySymbol.OrderBy(c => c.Key))
            {
                Console.WriteLine("{0} -> {1}", star.Key, star.Value);
            }
        }

        static bool IsStarCenter(char[,,] cube, int i, int j, int k)
        {
            if (cube[i - 1, j, k] == cube[i, j, k] && cube[i + 1, j, k] == cube[i, j, k] && cube[i, j - 1, k] == cube[i, j, k]
                && cube[i, j + 1, k] == cube[i, j, k] && cube[i, j, k - 1] == cube[i, j, k] && cube[i, j, k + 1] == cube[i, j, k])
            {
                return true;
            }
            return false;
        }
    }
}

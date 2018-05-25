using System;
using System.Linq;

namespace WrongResults
{
    class WrongResults
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,,] cube = new int[n, n, n];
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < n; layer++)
                {
                    int[] token = input[layer].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    for (int column = 0; column < n; column++)
                    {
                        cube[layer, row, column] = token[column];
                    }
                }
            }
            int[] wrongCoordinate = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int wrongNumber = cube[wrongCoordinate[0], wrongCoordinate[1], wrongCoordinate[2]];
            bool[,,] cubeWrongs = new bool[n, n, n];
            int countWrongs = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (cube[i, j, k] == wrongNumber)
                        {
                            cubeWrongs[i, j, k] = true;
                            countWrongs++;
                        }
                        else
                        {
                            cubeWrongs[i, j, k] = false;
                        }
                    }
                }
            }
            Console.WriteLine("Wrong values found and replaced: {0}", countWrongs);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (cubeWrongs[i, j, k])
                        {
                            cube[i, j, k] = SumArround(i, j, k, n, cube, cubeWrongs);
                        }
                        Console.Write(cube[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int SumArround(int layer, int row, int column, int n, int[,,] cube, bool[,,] cubeWrongs)
        {
            int sum = 0;
            int up = layer - 1 < 0 ? 0 : layer - 1;
            int down = layer + 1 > n - 1 ? n - 1 : layer + 1;
            int forward = row - 1 < 0 ? 0 : row - 1; ;
            int back = row + 1 > n - 1 ? n - 1 : row + 1; ;
            int left = column - 1 < 0 ? 0 : column - 1;
            int right = column + 1 > n - 1 ? n - 1 : column + 1;
            sum = (cubeWrongs[up, row, column] ? 0 : cube[up, row, column])
                + (cubeWrongs[down, row, column] ? 0 : cube[down, row, column])
                + (cubeWrongs[layer, forward, column] ? 0 : cube[layer, forward, column])
                + (cubeWrongs[layer, back, column] ? 0 : cube[layer, back, column])
                + (cubeWrongs[layer, row, left] ? 0 : cube[layer, row, left])
                + (cubeWrongs[layer, row, right] ? 0 : cube[layer, row, right]);
            return sum;
        }
    }
}
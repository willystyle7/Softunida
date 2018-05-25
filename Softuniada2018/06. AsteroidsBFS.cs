using System;
using System.Collections.Generic;
using System.Linq;

namespace AsteroidsBFC
{
    class AsteroidsBFC
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                int rows = int.Parse(input.Split('x')[0]);
                int columns = int.Parse(input.Split('x')[1]);
                int[,] matrix = new int[rows, columns];
                for (int i = 0; i < rows; i++)
                {
                    string line = Console.ReadLine();
                    for (int j = 0; j < columns; j++)
                    {
                        matrix[i, j] = line[j] - '0';
                    }
                }
                List<int> asteroids = new List<int>();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (matrix[i, j] != 0)
                        {
                            int asteroid = 0;
                            matrix[i, j] = 0;
                            TraverseBFS(matrix, rows, columns, i, j, ref asteroid);
                            asteroids.Add(asteroid);
                        }
                    }
                }
                asteroids = asteroids.OrderByDescending(a => a).ToList();
                //Console.WriteLine(string.Join("\n", asteroids));

                var groupsAsteroids = asteroids.GroupBy(a => a);
                foreach (var group in groupsAsteroids)
                {
                    Console.WriteLine("{0}x{1}", group.Count(), group.Key);
                }
                Console.WriteLine("Total: {0}", asteroids.Count);

                //Dictionary<int, int> asteroidsByCount = new Dictionary<int, int>();
                //foreach (int asteroid in asteroids)
                //{
                //    if (asteroidsByCount.ContainsKey(asteroid))
                //        asteroidsByCount[asteroid]++;
                //    else
                //        asteroidsByCount[asteroid] = 1;
                //}
                //foreach (var pair in asteroidsByCount)
                //    Console.WriteLine("{0}x{1}", pair.Value, pair.Key);
                //Console.WriteLine("Total: {0}", asteroids.Count);

                input = Console.ReadLine();
            }
        }

        private static void TraverseBFS(int[,] matrix, int rows, int columns, int startRow, int startCol, ref int asteroid)
        {
            //matrix.GetLength(0)
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(startRow, startCol));
            while (queue.Count > 0)
            {
                var next = queue.Dequeue();
                int row = next.Item1;
                int col = next.Item2;
                asteroid++;
                if ((row - 1 >= 0) && matrix[row - 1, col] != 0)
                {
                    matrix[row - 1, col] = 0;
                    queue.Enqueue(Tuple.Create(row - 1, col));
                }
                if ((row + 1 < rows) && matrix[row + 1, col] != 0)
                {
                    matrix[row + 1, col] = 0;
                    queue.Enqueue(Tuple.Create(row + 1, col));
                }
                if ((col - 1 >= 0) && matrix[row, col - 1] != 0)
                {
                    matrix[row, col - 1] = 0;
                    queue.Enqueue(Tuple.Create(row, col - 1));
                }
                if ((col + 1 < columns) && matrix[row, col + 1] != 0)
                {
                    matrix[row, col + 1] = 0;
                    queue.Enqueue(Tuple.Create(row, col + 1));
                }
            }
        }

        private static void TraverseDFS(int[,] matrix, int rows, int columns, int row, int col, ref int asteroid)
        {
            asteroid++;
            matrix[row, col] = 0;
            //ako i diagonalite sa svyrzani
            //for (int i = -1; i <= 1; i++)
            //{
            //    if ((row + i >= 0) && (row + i < rows))
            //    {
            //        for (int j = -1; j <= 1; j++)
            //        {
            //            if ((col + j >= 0) && (col + j < columns))
            //            {
            //                if (matrix[row + i, col + j] != 0)
            //                {
            //                    Traverse(matrix, rows, columns, row + i, col + j, ref asteroid);
            //                }
            //            }
            //        }
            //    }
            //}
            if ((row - 1 >= 0) && matrix[row - 1, col] != 0) TraverseDFS(matrix, rows, columns, row - 1, col, ref asteroid);
            if ((row + 1 < rows) && matrix[row + 1, col] != 0) TraverseDFS(matrix, rows, columns, row + 1, col, ref asteroid);
            if ((col - 1 >= 0) && matrix[row, col - 1] != 0) TraverseDFS(matrix, rows, columns, row, col - 1, ref asteroid);
            if ((col + 1 < columns) && matrix[row, col + 1] != 0) TraverseDFS(matrix, rows, columns, row, col + 1, ref asteroid);
            return;
        }

    }
}
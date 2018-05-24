using System;

namespace Snake
{
    class Snake
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,,] cube = new char[n, n, n];
            int currentLayer = 0, currentRow = 0, currentColumn = 0;
            int apples = 0;
            bool isDead = false;
            for (int row = 0; row < n; row++)
            {
                string[] input = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                for (int layer = 0; layer < n; layer++)
                {
                    for (int column = 0; column < n; column++)
                    {
                        cube[layer, row, column] = input[layer][column];
                        if (cube[layer, row, column] == 's')
                        {
                            currentLayer = layer;
                            currentRow = row;
                            currentColumn = column;
                        }
                    }
                }
            }
            string direction = Console.ReadLine();
            do
            {
                string[] commands = Console.ReadLine().Split();
                int steps = int.Parse(commands[2]);
                switch (direction)
                {
                    case "up":
                        for (int i = currentLayer; i >= currentLayer - steps; i--)
                        {
                            if (i < 0)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[i, currentRow, currentColumn] == 'a')
                            {
                                cube[i, currentRow, currentColumn] = 'o';
                                apples++;
                            }
                        }
                        currentLayer -= steps;
                        break;
                    case "down":
                        for (int i = currentLayer; i <= currentLayer + steps; i++)
                        {
                            if (i > n - 1)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[i, currentRow, currentColumn] == 'a')
                            {
                                cube[i, currentRow, currentColumn] = 'o';
                                apples++;
                            }
                        }
                        currentLayer += steps;
                        break;
                    case "forward":
                        for (int i = currentRow; i >= currentRow - steps; i--)
                        {
                            if (i < 0)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[currentLayer, i, currentColumn] == 'a')
                            {
                                cube[currentLayer, i, currentColumn] = 'o';
                                apples++;
                            }
                        }
                        currentRow -= steps;
                        break;
                    case "backward":
                        for (int i = currentRow; i <= currentRow + steps; i++)
                        {
                            if (i > n - 1)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[currentLayer, i, currentColumn] == 'a')
                            {
                                cube[currentLayer, i, currentColumn] = 'o';
                                apples++;
                            }
                        }
                        currentRow += steps;
                        break;
                    case "left":
                        for (int i = currentColumn; i >= currentColumn - steps; i--)
                        {
                            if (i < 0)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[currentLayer, currentRow, i] == 'a')
                            {
                                cube[currentLayer, currentRow, i] = 'o';
                                apples++;
                            }
                        }
                        currentColumn -= steps;
                        break;
                    case "right":
                        for (int i = currentColumn; i <= currentColumn + steps; i++)
                        {
                            if (i > n - 1)
                            {
                                isDead = true;
                                break;
                            }
                            if (cube[currentLayer, currentRow, i] == 'a')
                            {
                                cube[currentLayer, currentRow, i] = 'o';
                                apples++;
                            }
                        }
                        currentColumn += steps;
                        break;
                }
                direction = commands[0];
            } while (direction != "end" && !isDead);
            Console.WriteLine("Points collected: {0}", apples);
            Console.WriteLine(isDead ? "The snake dies." : "");
        }
    }
}
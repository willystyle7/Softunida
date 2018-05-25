using System;
using System.Linq;

namespace CarBitMap
{
    class CarBitMap
    {
        static void Main()
        {
            int c = int.Parse(Console.ReadLine());
            int[] velocities = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startVelocity = int.Parse(Console.ReadLine());
            int maxVelocity = int.Parse(Console.ReadLine());
            int[] possibleVelocity = new int[maxVelocity + 1];
            possibleVelocity[startVelocity] = 1;
            for (int i = 0; i < c; i++)
            {
                int[] newPossibleVelocity = new int[maxVelocity + 1];
                for (int j = 0; j <= maxVelocity; j++)
                {
                    if (possibleVelocity[j] != 0)
                    {
                        if (j + velocities[i] <= maxVelocity) newPossibleVelocity[j + velocities[i]] = 1;
                        if (j - velocities[i] >= 0) newPossibleVelocity[j - velocities[i]] =1;
                    }
                }
                possibleVelocity = newPossibleVelocity;
            }
            for (int i = maxVelocity; i >= 0; i--)
            {
                if (possibleVelocity[i] == 1)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("-1");
        }
    }
}

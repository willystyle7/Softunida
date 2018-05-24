using System;
using System.Linq;

namespace ShopKeeper
{
    class ShopKeeper
    {
        static void Main()
        {
            int[] store = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] storeIndexes = new int[store.Length];
            if (!store.Contains(orders[0]))
            {
                Console.WriteLine("impossible");
                return;
            }
            for (int i = 0; i < store.Length; i++)
            {
                storeIndexes[i] = Array.IndexOf(orders, store[i], 1);
            }
            int changes = 0;
            for (int j = 1; j < orders.Length; j++)
            {
                if (!store.Contains(orders[j]))
                {
                    int maxIndex = -1;
                    int storeIndex = -1;
                    for (int i = 0; i < store.Length; i++)
                    {                        
                        int index = storeIndexes[i];
                        if (index == -1)
                        {
                            storeIndex = i;
                            break;
                        }
                        else if (index > maxIndex)
                        {
                            maxIndex = index;
                            storeIndex = i;
                        }
                    }
                    store[storeIndex] = orders[j];
                    storeIndexes[storeIndex] = Array.IndexOf(orders, store[storeIndex], j + 1);
                    changes++;
                }
                else
                {
                    storeIndexes[Array.IndexOf(store, orders[j])] = Array.IndexOf(orders, orders[j], j + 1);
                }
            }
            Console.WriteLine(changes);
        }
    }
}
using System;
using System.Collections.Generic;

class DowntoZeroII
{
    static void Main(string[] args)
    {
        Console.WriteLine(downToZero(10));
    }

    static int downToZero(int n)
    {
        int[] distance = new int[n + 1];
        Queue<int> q = new Queue<int>();
        q.Enqueue(n);
        distance[n] = 0;
        int current = 0;
        int count = 0;
        if (n == 0)
        {
            return 0;
        }
        while (q.Count > 0)
        {
            current = q.Dequeue();
            count = distance[current];
            if (current == 1)
            {
                return count + 1;
            }
            if (distance[current - 1] == 0)
            {
                distance[current - 1] = count + 1;
                q.Enqueue(current - 1);
            }
            for (int i = 2; i * i <= current; i++)
            {
                if (current % i == 0)
                {
                    int fact = Math.Max(current / i, i);
                    if (distance[fact] == 0)
                    {
                        distance[fact] = count + 1;
                        q.Enqueue(fact);
                    }
                }
            }
        }
        return 0;
    }
}

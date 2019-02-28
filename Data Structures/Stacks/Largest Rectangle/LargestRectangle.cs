using System;
using System.Collections.Generic;

class Program
{
    static long largestRectangle(int[] h)
    {
        int n = h.Length;
        long max = 0;
        Stack<int> s = new Stack<int>();
        int i = 0;
        while (i < n)
        {
            if (s.Count == 0 || h[i] >= h[s.Peek()])
            {
                s.Push(i);
                i++;
            }
            else
            {
                int pop = s.Pop();
                if (s.Count == 0)
                {
                    max = Math.Max(max, h[pop] * i);
                }
                else
                {
                    max = Math.Max(max, h[pop] * (i - s.Peek() - 1));
                }
            }
        }
        while (s.Count > 0)
        {
            int pop = s.Pop();
            if (s.Count == 0)
            {
                max = Math.Max(max, h[pop] * n);
            }
            else
            {
                max = Math.Max(max, h[pop] * (n - s.Peek() - 1));
            }
        }
        return max;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(largestRectangle(new int[] { 1, 2, 3, 4, 5 }));
    }
}

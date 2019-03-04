using System;
using System.Collections.Generic;

class FindMaximumIndexProduct
{
    static long solve(int[] arr)
    {
        Stack<int> values = new Stack<int>();
        Stack<int> index = new Stack<int>();
        int start = 0;
        //skip the elements for which Left(i) will be zero
        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                start = i + 1;
                values.Push(arr[i]);
                index.Push(i);
                break;
            }
        }
        if (values.Count == 0)
        {
            return 0;
        }
        long max = 0;
        long currentmax = 0;
        for (int i = start; i < arr.Length; i++)
        {
            int top = int.MaxValue;
            if (values.Count > 0)
            {
                top = values.Peek();
            }
            if (top < arr[i])
            {
                values.Pop();
                index.Pop();
                if (values.Count > 0)
                {
                    int left = index.Peek();
                    currentmax = (long)(left + 1) * (i + 1);
                    max = Math.Max(max, currentmax);
                }
                i--;
            }
            else if (top > arr[i])
            {
                values.Push(arr[i]);
                index.Push(i);
            }
            else
            {
                index.Pop();
                index.Push(i);
            }
        }
        return max;
    }

    static void Main(string[] args)
    {
        int[] input = new int[] { 5, 4, 3, 4, 5 };
        Console.WriteLine(solve(input));
    }
}
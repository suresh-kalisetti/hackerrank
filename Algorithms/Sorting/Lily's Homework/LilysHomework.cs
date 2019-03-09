using System;
using System.Collections.Generic;
using System.Linq;

class LilysHomework
{
    static int lilysHomework(int[] arr)
    {
        int n = arr.Length;
        List<KeyValuePair<int, int>> sorted = new List<KeyValuePair<int, int>>();
        for (int i = 0; i < n; i++)
        {
            sorted.Add(new KeyValuePair<int, int>(arr[i], i));
        }
        sorted.Sort((x, y) => x.Key.CompareTo(y.Key));
        Print(sorted);
        bool[] used = new bool[n];
        int cyclecount = 0;
        for (int i = 0; i < n; i++)
        {
            if (used[i] != true)
            {
                cyclecount++;
                UpdateCycle(sorted, used, i);
            }
        }
        int result = n - cyclecount;
        cyclecount = 0;
        used = new bool[n];
        sorted.Reverse();
        for (int i = 0; i < n; i++)
        {
            if (used[i] != true)
            {
                cyclecount++;
                UpdateCycle(sorted, used, i);
            }
        }
        return Math.Min(n - cyclecount, result);
    }

    static void UpdateCycle(List<KeyValuePair<int, int>> input, bool[] used, int index)
    {
        if (used[index])
        {
            return;
        }
        else
        {
            used[index] = true;
            UpdateCycle(input, used, input[index].Value);
        }
    }

    static void Main(string[] args)
    {
        int[] input = new int[] { 2, 5, 3, 1 };
        Console.WriteLine(lilysHomework(input));
    }
}

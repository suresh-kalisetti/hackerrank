using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TheFullCountingSort
{
    static void countSort(List<List<string>> arr)
    {
        int n = arr.Count();
        int[] counts = new int[100];
        int[] currentcounts = new int[100];
        int half = n / 2;
        int count = 1;
        foreach (List<string> list in arr)
        {
            int i = Convert.ToInt32(list[0]);
            if (count <= half)
            {
                currentcounts[i]++;
            }
            counts[i]++;
            count++;
        }
        for (int i = 1; i < 100; i++)
        {
            counts[i] += counts[i - 1];
        }
        string[] result = new string[n];
        for (int i = half; i < n; i++)
        {
            string s = arr[i][1];
            int j = Convert.ToInt32(arr[i][0]);
            int index = 0;
            if (j - 1 >= 0)
            {
                index = counts[j - 1] + currentcounts[j];
            }
            else
            {
                index = currentcounts[j];
            }
            result[index] = s;
            currentcounts[j]++;
        }
        StringBuilder sb = new StringBuilder();
        foreach (string s in result)
        {
            if (s == null)
            {
                sb.Append("- ");
            }
            else
            {
                sb.Append(s + " ");
            }
        }
        Console.WriteLine(sb);
    }

    static void Main(string[] args)
    {
        List<List<string>> input = new List<List<string>>();
        input.Add(new List<string> { "1", "e" });
        input.Add(new List<string> { "2", "a" });
        input.Add(new List<string> { "1", "b" });
        input.Add(new List<string> { "3", "a" });
        input.Add(new List<string> { "4", "f" });
        input.Add(new List<string> { "1", "f" });
        input.Add(new List<string> { "2", "a" });
        input.Add(new List<string> { "1", "e" });
        input.Add(new List<string> { "1", "b" });
        input.Add(new List<string> { "1", "c" });
        countSort(input);
    }
}

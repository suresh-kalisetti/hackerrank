using System;
using System.Collections.Generic;

class Contacts
{
    static int[] contacts(string[][] queries)
    {
        Node root = new Node();
        List<int> result = new List<int>();
        for (int i = 0; i < queries.Length; i++)
        {
            if (queries[i][0] == "add")
            {
                string input = queries[i][1];
                Add(root, input);
            }
            else
            {
                string input = queries[i][1];
                result.Add(Find(root, input));
            }
        }
        return result.ToArray();
    }

    static void Add(Node start, string input)
    {
        foreach (char c in input)
        {
            int index = ((int)c) - 97;
            if (start.next[index] == null)
            {
                start.next[index] = new Node();
            }
            start.next[index].count += 1;
            start = start.next[index];
        }
    }

    static int Find(Node start, string input)
    {
        int count = 0;
        foreach (char c in input)
        {
            int index = ((int)c) - 97;
            if (start.next[index] == null)
            {
                return 0;
            }
            start = start.next[index];
            count = start.count;
        }
        return count;
    }

    static void Main(string[] args)
    {
        string[][] input = new string[4][];
        input[0] = new string[] { "add", "hack" };
        input[1] = new string[] { "add", "hackerrank" };
        input[2] = new string[] { "find", "hac" };
        input[3] = new string[] { "find", "hak" };
        foreach(int i in contacts(input))
        {
            Console.WriteLine(i);
        }
    }
}

class Node
{
    public int count;
    public Node[] next = new Node[26];
}
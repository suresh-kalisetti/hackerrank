using System;
using System.Collections.Generic;

class QueueusingTwoStacks
{
    static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        Stack<int> stackinsert = new Stack<int>();
        Stack<int> stackdelete = new Stack<int>();
        for (int i = 0; i < t; i++)
        {
            String line = Console.ReadLine();
            int operation = Convert.ToInt32(line.Split(' ')[0]);
            if (operation == 1)
            {
                int val = Convert.ToInt32(line.Split(' ')[1]);
                stackinsert.Push(val);
            }
            else if (operation == 2)
            {
                if (stackdelete.Count == 0)
                {
                    CopyStack(stackinsert, stackdelete);
                    stackdelete.Pop();
                }
                else
                {
                    stackdelete.Pop();
                }
            }
            else
            {
                if (stackdelete.Count == 0)
                {
                    CopyStack(stackinsert, stackdelete);
                }
                int val = stackdelete.Peek();
                Console.WriteLine(val);
            }
        }
    }

    static void CopyStack(Stack<int> source, Stack<int> destination)
    {
        int n = source.Count;
        while (n > 0)
        {
            int i = source.Pop();
            destination.Push(i);
            n--;
        }
    }
}

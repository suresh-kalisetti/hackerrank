using System;
using System.Collections.Generic;

class BalancedBrackets
{
    static string isBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return "NO";
                }
                char top = stack.Pop();
                if ((c == ')' && top != '(') || (c == ']' && top != '[') || (c == '}' && top != '{'))
                {
                    return "NO";
                }
            }
        }
        if (stack.Count > 0)
        {
            return "NO";
        }
        return "YES";
    }

    static void Main(string[] args)
    {
        Console.WriteLine(isBalanced("{[(])}"));
    }
}

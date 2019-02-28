using System;
using System.Collections.Generic;

class SimpleTextEditor
{
    static void Main(String[] args)
    {
        string str = "";
        int t = Convert.ToInt32(Console.ReadLine());
        Stack<string> operations = new Stack<string>();
        while (t > 0)
        {
            string temp = Console.ReadLine();
            string type = temp.Split(' ')[0];
            if (type == "1")
            {
                operations.Push(str);
                str += temp.Split(' ')[1];
            }
            else if (type == "2")
            {
                operations.Push(str);
                int k = Convert.ToInt32(temp.Split(' ')[1]);
                str = str.Substring(0, str.Length - k);
            }
            else if (type == "3")
            {
                int k = Convert.ToInt32(temp.Split(' ')[1]);
                Console.WriteLine(str[k - 1]);
            }
            else
            {
                str = operations.Pop();
            }
            t--;
        }
    }
}

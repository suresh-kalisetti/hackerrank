using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameofTwoStacks
{
    static void Main(string[] args)
    {
        int[] a = new int[] { 4, 2, 4, 6, 1 };
        int[] b = new int[] { 2, 1, 8, 5 };
        Console.WriteLine(twoStacks(10, a, b));
    }

    static int twoStacks(int x, int[] a, int[] b)
    {
        Stack<int> s = new Stack<int>();
        int sum = 0;
        int max = 0;
        int count = 0;
        while (count < a.Length && sum + a[count] <= x)
        {
            sum += a[count];
            s.Push(a[count]);
            count++;
        }
        max = count;
        for (int i = 0; i < b.Length; i++)
        {
            while (sum + b[i] > x && s.Count > 0)
            {
                int temp = s.Pop();
                count--;
                sum -= temp;
            }
            if (sum + b[i] > x)
            {
                break;
            }
            count++;
            sum += b[i];
            max = Math.Max(count, max);
        }
        return max;
    }
}

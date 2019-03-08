using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FraudulentActivityNotifications
{
    static int activityNotifications(int[] expenditure, int d)
    {
        int n = expenditure.Length;
        int[] counts = new int[201];
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            if (i < d)
            {
                counts[expenditure[i]]++;
            }
            else
            {
                int middle1 = GetNthNumber(counts, d / 2 + 1);
                if (d % 2 == 0)
                {
                    int middle2 = GetNthNumber(counts, d / 2);
                    if (expenditure[i] >= middle1 + middle2)
                    {
                        result++;
                    }
                }
                else
                {
                    if (expenditure[i] >= (2 * middle1))
                    {
                        result++;
                    }
                }
                counts[expenditure[i - d]]--;
                counts[expenditure[i]]++;
            }
        }
        return result;
    }

    static int GetNthNumber(int[] counts, int n)
    {
        int count = 0;
        int result = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            count += counts[i];
            if (count >= n)
            {
                result = i;
                break;
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        int[] input = new int[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
        Console.WriteLine(activityNotifications(input, 5));
    }
}

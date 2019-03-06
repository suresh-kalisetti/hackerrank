using System;

class FormingaMagicSquare
{
    static int result = int.MaxValue;
    static int formingMagicSquare(int[][] s)
    {
        int[][] ms = new int[3][];
        ms[0] = new int[] { 0, 0, 0 };
        ms[1] = new int[] { 0, 0, 0 };
        ms[2] = new int[] { 0, 0, 0 };
        Recursive(s, ms, 0, 0, new int[10]);
        return result;
    }

    static void Recursive(int[][] s, int[][] ms, int i, int j, int[] values)
    {
        if (i == 3 && j == 0 && IsMagicSquare(ms))
        {
            int cost = GetCost(s, ms);
            if (cost < result)
            {
                result = cost;
            }
            return;
        }
        else
        {
            for (int k = 1; k < 10; k++)
            {
                if (values[k] == 0)
                {
                    ms[i][j] = k;
                    values[k] = -1;
                    int tempi = i;
                    int tempj = j;
                    if (j + 1 < 3)
                    {
                        tempj++;
                    }
                    else
                    {
                        tempi++;
                        tempj = 0;
                    }
                    Recursive(s, ms, tempi, tempj, values);
                    values[k] = 0;
                }
            }
        }
    }

    static int GetCost(int[][] s, int[][] ms)
    {
        return Math.Abs(s[0][0] - ms[0][0]) + Math.Abs(s[0][1] - ms[0][1]) + Math.Abs(s[0][2] - ms[0][2]) + Math.Abs(s[1][0] - ms[1][0]) + Math.Abs(s[1][1] - ms[1][1]) + Math.Abs(s[1][2] - ms[1][2]) + Math.Abs(s[2][0] - ms[2][0]) + Math.Abs(s[2][1] - ms[2][1]) + Math.Abs(s[2][2] - ms[2][2]);
    }

    static bool IsMagicSquare(int[][] s)
    {
        int sum = s[0][0] + s[0][1] + s[0][2];
        if (s[1][0] + s[1][1] + s[1][2] != sum || s[2][0] + s[2][1] + s[2][2] != sum ||
           s[0][0] + s[1][0] + s[2][0] != sum || s[0][1] + s[1][1] + s[2][1] != sum ||
           s[0][2] + s[1][2] + s[2][2] != sum || s[0][0] + s[1][1] + s[2][2] != sum ||
           s[0][2] + s[1][1] + s[2][0] != sum)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    static void Main(string[] args)
    {
        int[][] input = new int[3][];
        input[0] = new int[] { 5, 3, 4 };
        input[1] = new int[] { 1, 5, 8 };
        input[2] = new int[] { 6, 4, 2 };
        Console.WriteLine(formingMagicSquare(input));
    }
}

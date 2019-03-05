using System;
using System.Collections.Generic;
using System.IO;

class MrXandHisShots
{
    static int solve(int[][] shots, int[][] players)
    {
        List<int> start = new List<int>();
        List<int> end = new List<int>();
        int n = shots.Length;
        for (int i = 0; i < n; i++)
        {
            start.Add(shots[i][0]);
            end.Add(shots[i][1]);
        }
        start.Sort();
        end.Sort();
        int m = players.Length;
        int sum = 0;
        for (int i = 0; i < m; i++)
        {
            int x = players[i][0];
            int y = players[i][1];
            int startindex = end.BinarySearch(x);
            if (startindex < 0)
            {
                startindex = ~startindex;
            }
            else
            {
                //reduce start if there are duplicates
                while (startindex - 1 >= 0 && end[startindex - 1] == x)
                {
                    startindex--;
                }
            }
            int endindex = start.BinarySearch(y);
            if (endindex < 0)
            {
                endindex = ~endindex - 1;
            }
            else
            {
                //increase end if there are duplicates
                while (endindex + 1 < n && start[endindex + 1] == y)
                {
                    endindex++;
                }
            }
            sum += endindex - startindex + 1;
        }
        return sum;
    }

    static void Main(string[] args)
    {
        int[][] stones = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7 }, };
        int[][] players = new int[][] { new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 4, 7 }, new int[] { 5, 6 }, };
        Console.WriteLine(solve(stones, players));
    }
}

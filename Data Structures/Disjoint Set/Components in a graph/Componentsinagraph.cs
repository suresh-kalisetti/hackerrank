using System;

class Componentsinagraph
{
    static int[] componentsInGraph(int[][] gb)
    {
        int n = gb.Length;
        int[] disjointset = new int[(2 * n) + 1];
        for (int i = 0; i < (2 * n) + 1; i++)
        {
            disjointset[i] = -1;
        }
        for (int i = 0; i < n; i++)
        {
            int x = gb[i][0];
            int y = gb[i][1];
            int xparent = x;
            int yparent = y;
            //find parent nodes of each vertex
            while (disjointset[xparent] > 0)
            {
                xparent = disjointset[xparent];
            }
            while (disjointset[yparent] > 0)
            {
                yparent = disjointset[yparent];
            }
            //update the parent nodes to reuse in future iterations
            if (xparent != x)
            {
                disjointset[x] = xparent;
            }
            if (yparent != y)
            {
                disjointset[y] = yparent;
            }
            //both vertex belogs to the same set, no need to add
            if (xparent == yparent)
            {
                continue;
            }
            //pick the maximum weight subset and perform union
            if (disjointset[xparent] <= disjointset[yparent])
            {
                int temp = disjointset[yparent];
                disjointset[yparent] = xparent;
                disjointset[xparent] += temp;
            }
            else
            {
                int temp = disjointset[xparent];
                disjointset[xparent] = yparent;
                disjointset[yparent] += temp;
            }
        }
        int min = 2 * n;
        int max = 0;
        //iterate through all the nodes and take the maximum and minimum weights
        for (int i = 1; i < disjointset.Length; i++)
        {
            if (disjointset[i] < -1)
            {
                int temp = 0 - disjointset[i];
                max = Math.Max(temp, max);
                min = Math.Min(temp, min);
            }
        }
        return new int[] { min, max };
    }

    static void Main(string[] args)
    {
        int[][] edges = new int[5][];
        edges[0] = new int[] { 1, 6 };
        edges[1] = new int[] { 2, 7 };
        edges[2] = new int[] { 3, 8 };
        edges[3] = new int[] { 4, 9 };
        edges[4] = new int[] { 2, 6 };
        int[] result = componentsInGraph(edges);
        Console.WriteLine(result[0] + " " + result[1]);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SwapNodesAlgo
{
    static void Main(string[] args)
    {
        int[][] indexes = new int[11][];
        indexes[0] = new int[] { 2, 3 };
        indexes[1] = new int[] { 4, -1 };
        indexes[2] = new int[] { 5, -1 };
        indexes[3] = new int[] { 6, -1 };
        indexes[4] = new int[] { 7, 8 };
        indexes[5] = new int[] { -1, 9 };
        indexes[6] = new int[] { -1, -1 };
        indexes[7] = new int[] { 10, 11 };
        indexes[8] = new int[] { -1, -1 };
        indexes[9] = new int[] { -1, -1 };
        indexes[10] = new int[] { -1, -1 };
        int[] queries = new int[] { 2, 4 };
        int[][] result = swapNodes(indexes, queries);
        for(int i=0;i<result.Length;i++)
        {
            foreach(int j in result[i])
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }

    static int[][] swapNodes(int[][] indexes, int[] queries)
    {
        int n = indexes.Length;
        Node[] tree = new Node[n];
        Dictionary<int, List<Node>> depths = new Dictionary<int, List<Node>>();
        for (int i = 1; i <= n; i++)
        {
            tree[i - 1] = new Node(i);
        }
        for (int i = 0; i < n; i++)
        {
            int left = indexes[i][0];
            int right = indexes[i][1];
            if (left != -1)
            {
                tree[i].left = tree[left - 1];
            }
            if (right != -1)
            {
                tree[i].right = tree[right - 1];
            }
        }
        dfs(tree[0], 1, depths);
        int[][] finalresult = new int[queries.Length][];
        for (int i = 0; i < queries.Length; i++)
        {
            int k = queries[i];
            int increment = k;
            while (depths.ContainsKey(k))
            {
                foreach (Node current in depths[k])
                {
                    Node temp = current.left;
                    current.left = current.right;
                    current.right = temp;
                }
                k += increment;
            }
            List<int> result = new List<int>();
            InOrderTraversal(tree[0], result);
            finalresult[i] = result.ToArray();
        }
        return finalresult;
    }

    static void dfs(Node start, int d, Dictionary<int, List<Node>> depths)
    {
        if (start == null)
        {
            return;
        }
        if (depths.ContainsKey(d))
        {
            depths[d].Add(start);
        }
        else
        {
            depths.Add(d, new List<Node> { start });
        }
        dfs(start.left, d + 1, depths);
        dfs(start.right, d + 1, depths);
    }

    static void InOrderTraversal(Node start, List<int> result)
    {
        if (start == null)
        {
            return;
        }
        InOrderTraversal(start.left, result);
        result.Add(start.value);
        InOrderTraversal(start.right, result);
    }
}

class Node
{
    public int value;
    public Node(int val)
    {
        this.value = val;
    }
    public Node left;
    public Node right;
}

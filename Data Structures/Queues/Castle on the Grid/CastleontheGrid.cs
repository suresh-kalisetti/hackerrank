using System;
using System.Collections.Generic;

class CastleontheGrid
{
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY)
    {
        int n = grid.Length;
        bool[,] visited = new bool[n, n];
        int[,] distance = new int[n, n];
        Node start = new Node(startX, startY, 0);
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(start);
        visited[startX, startY] = true;
        while (q.Count > 0)
        {
            Node current = q.Dequeue();
            int x = current.x;
            int y = current.y;
            int d = current.distance;
            //left
            for (int i = 1; y - i >= 0; i++)
            {
                if (grid[x][y - i] == 'X')
                {
                    break;
                }
                if (!visited[x, y - i])
                {
                    visited[x, y - i] = true;
                    distance[x, y - i] = d + 1;
                    q.Enqueue(new Node(x, y - i, d + 1));
                }
            }
            //right
            for (int i = 1; y + i < n; i++)
            {
                if (grid[x][y + i] == 'X')
                {
                    break;
                }
                if (!visited[x, y + i])
                {
                    visited[x, y + i] = true;
                    distance[x, y + i] = d + 1;
                    q.Enqueue(new Node(x, y + i, d + 1));
                }
            }
            //up
            for (int i = 1; x - i >= 0; i++)
            {
                if (grid[x - i][y] == 'X')
                {
                    break;
                }
                if (!visited[x - i, y])
                {
                    visited[x - i, y] = true;
                    distance[x - i, y] = d + 1;
                    q.Enqueue(new Node(x - i, y, d + 1));
                }
            }
            //down
            for (int i = 1; x + i < n; i++)
            {
                if (grid[x + i][y] == 'X')
                {
                    break;
                }
                if (!visited[x + i, y])
                {
                    visited[x + i, y] = true;
                    distance[x + i, y] = d + 1;
                    q.Enqueue(new Node(x + i, y, d + 1));
                }
            }
        }
        return distance[goalX, goalY];
    }

    static void Main(string[] args)
    {
        string[] grid = new string[] { ".X.", ".X.", "..." };
        Console.WriteLine(minimumMoves(grid, 0, 0, 0, 2));
    }
}

class Node
{
    public int x;
    public int y;
    public int distance;
    public Node(int x1, int y1, int d1)
    {
        this.x = x1;
        this.y = y1;
        this.distance = d1;
    }
}

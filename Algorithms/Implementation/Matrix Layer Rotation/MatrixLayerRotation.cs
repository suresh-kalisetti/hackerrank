using System;
using System.Collections.Generic;
using System.Linq;

class MatrixLayerRotation
{
    static void matrixRotation(List<List<int>> matrix, int r)
    {
        int m = matrix.Count();
        int n = matrix[0].Count();
        int iterations = Math.Min(m, n) / 2;
        for (int i = 0; i < iterations; i++)
        {
            List<int> layer = GetLayer(matrix, m - i, n - i, 0 + i, 0 + i);
            int index = r % layer.Count();
            RotateLayer(matrix, layer, index, m - i, n - i, 0 + i, 0 + i);
        }
        PrintMatrix(matrix);
    }

    static void RotateLayer(List<List<int>> matrix, List<int> input, int index, int m, int n, int x, int y)
    {
        int count = input.Count();
        //first row
        for (int i = y; i < n - 1; i++)
        {
            matrix[x][i] = input[index];
            index = (index + 1) % count;
        }
        //last column
        for (int i = x; i < m - 1; i++)
        {
            matrix[i][n - 1] = input[index];
            index = (index + 1) % count;
        }
        //last row
        for (int i = n - 1; i > y; i--)
        {
            matrix[m - 1][i] = input[index];
            index = (index + 1) % count;
        }
        //first column
        for (int i = m - 1; i > x; i--)
        {
            matrix[i][y] = input[index];
            index = (index + 1) % count;
        }
    }

    static List<int> GetLayer(List<List<int>> matrix, int m, int n, int x, int y)
    {
        List<int> result = new List<int>();
        //first row
        for (int i = y; i < n - 1; i++)
        {
            result.Add(matrix[x][i]);
        }
        //last column
        for (int i = x; i < m - 1; i++)
        {
            result.Add(matrix[i][n - 1]);
        }
        //last row
        for (int i = n - 1; i > y; i--)
        {
            result.Add(matrix[m - 1][i]);
        }
        //first column
        for (int i = m - 1; i > x; i--)
        {
            result.Add(matrix[i][y]);
        }
        return result;
    }

    static void PrintMatrix(List<List<int>> matrix)
    {
        foreach (List<int> list in matrix)
        {
            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        List<List<int>> input = new List<List<int>>();
        input.Add(new List<int> { 1, 2, 3, 4 });
        input.Add(new List<int> { 7, 8, 9, 10 });
        input.Add(new List<int> { 13, 14, 15, 16 });
        input.Add(new List<int> { 19, 20, 21, 22 });
        input.Add(new List<int> { 25, 26, 27, 28 });
        matrixRotation(input, 7);
    }
}

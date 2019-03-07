using System;

class AlmostSorted
{
    static void almostSorted(int[] arr)
    {
        int n = arr.Length;
        if (isSorted(arr, 0, n - 1))
        {
            Console.WriteLine("yes");
            return;
        }
        else
        {
            int start = 0;
            int end = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    start = i;
                    break;
                }
            }
            for (int i = n - 1; i > 0; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    end = i;
                    break;
                }
            }
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
            if (isSorted(arr, 0, n - 1))
            {
                Console.WriteLine("yes\nswap " + (start + 1) + " " + (end + 1));
            }
            else
            {
                if (end - start - 1 > 0)
                {
                    int[] segment = new int[end - start - 1];
                    Array.Copy(arr, start + 1, segment, 0, end - start - 1);
                    Array.Reverse(segment);
                    Array.Copy(segment, 0, arr, start + 1, end - start - 1);
                    if (isSorted(arr, 0, n - 1))
                    {
                        Console.WriteLine("yes\nreverse " + (start + 1) + " " + (end + 1));
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }

    static bool isSorted(int[] input, int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            if (input[i] > input[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        int[] input = new int[] { 1, 5, 4, 3, 2, 6 };
        almostSorted(input);
    }
}

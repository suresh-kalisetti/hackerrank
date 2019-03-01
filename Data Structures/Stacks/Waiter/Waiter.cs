using System;

class Waiter
{
    static int[] waiter(int[] number, int q)
    {
        int[] primes = new int[q];
        int n = number.Length;
        getPrimes(primes, q);
        int[] result = new int[n];
        int index = 0;
        int i = 0;
        for (i = 0; i <= q; i++)
        {
            if ((i == q && i % 2 == 0) || (i < q && i % 2 != 0))
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (number[j] != -1)
                    {
                        if (i == q || number[j] % primes[i] == 0)
                        {
                            result[index] = number[j];
                            number[j] = -1;
                            index++;
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < n; j++)
                {
                    if (number[j] != -1)
                    {
                        if (i == q || number[j] % primes[i] == 0)
                        {
                            result[index] = number[j];
                            number[j] = -1;
                            index++;
                        }
                    }
                }
            }
        }
        return result;
    }

    static void getPrimes(int[] input, int q)
    {
        int i = 0;
        int j = 2;
        while (i < q)
        {
            bool found = true;
            for (int k = 2; k * k <= j; k++)
            {
                if (j % k == 0)
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                input[i] = j;
                i++;
            }
            j++;
        }
    }

    static void Main(string[] args)
    {
        foreach (int i in waiter(new int[] { 3, 3, 4, 4, 9 }, 2))
        {
            Console.WriteLine(i);
        }
    }
}

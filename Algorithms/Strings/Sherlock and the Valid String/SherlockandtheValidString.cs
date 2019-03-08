using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SherlockandtheValidString
{
    static string isValid(string s)
    {
        int[] counts = new int[26];
        foreach (char c in s)
        {
            int index = ((int)c) - 97;
            counts[index]++;
        }
        Array.Sort(counts);
        int minvalue = 0;
        int maxvalue = 0;
        int mincount = 0;
        int maxcount = 0;
        for (int i = 0; i < 26; i++)
        {
            if (counts[i] != 0)
            {
                if (minvalue == 0)
                {
                    minvalue = counts[i];
                    mincount++;
                }
                else
                {
                    if (counts[i] == minvalue)
                    {
                        mincount++;
                    }
                    else
                    {
                        if (maxvalue == 0)
                        {
                            maxvalue = counts[i];
                            maxcount++;
                        }
                        else
                        {
                            if (maxvalue != counts[i])
                            {
                                return "NO";
                            }
                            else
                            {
                                maxcount++;
                            }
                        }
                    }
                }
            }
        }
        if ((mincount >= 1 && maxcount == 0) || ((mincount == 1 && mincount * minvalue == 1) && maxcount > 1) || (maxvalue - minvalue == 1 && maxcount == 1))
        {
            return "YES";
        }
        else
        {
            return "NO";
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine(isValid("abcdefghhgfedecba"));
    }
}

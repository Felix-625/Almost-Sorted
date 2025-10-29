using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void almostSorted(List<int> arr)
    {
         List<int> sorted = arr.OrderBy(x => x).ToList();
        
        // Find positions where elements differ from sorted version
        List<int> diffIndices = new List<int>();
        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] != sorted[i])
            {
                diffIndices.Add(i);
            }
        }
        
        // If already sorted
        if (diffIndices.Count == 0)
        {
            Console.WriteLine("yes");
            return;
        }
        
        // Check if swapping two elements works
        if (diffIndices.Count == 2)
        {
            int i = diffIndices[0];
            int j = diffIndices[1];
            Console.WriteLine($"yes\nswap {i + 1} {j + 1}");
            return;
        }
        
        // Check if reversing a subarray works
        int start = diffIndices[0];
        int end = diffIndices[diffIndices.Count - 1];
        
        // Create reversed subarray
        List<int> reversedSegment = new List<int>();
        for (int i = end; i >= start; i--)
        {
            reversedSegment.Add(arr[i]);
        }
        
        // Check if reversed segment matches sorted version
        bool canReverse = true;
        for (int i = start; i <= end; i++)
        {
            if (arr[start + (end - i)] != sorted[i])
            {
                canReverse = false;
                break;
            }
        }
        
        if (canReverse)
        {
            Console.WriteLine($"yes\nreverse {start + 1} {end + 1}");
            return;
        }
        
        Console.WriteLine("no");

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.almostSorted(arr);
    }
}

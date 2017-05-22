using System;
using System.Diagnostics;

class Program
{

    /************************************************************************
    * 
    * TASK    
    * 
    * Write a quicksort function that calls the function insertion sort 
    * for sorting sublists of the size less than 10. 
    * 
    * In main():
    * Create int L[100] initialize it by random numbers, copy L into int L1[100]
    * Sort L by your combined quicksort, measure the time of execution, print sorted array L
    * Process L1 by an ordinary quicksort, measure the time, print sorted L1.
    * 
    * ************************************************************************
    * 
    * NOTE: How Quicksort works.
    * 
    * Quicksort is a divide and conquer algorithm. 
    * Quicksort first divides a large array into two smaller sub-arrays:
    * the low elements and the high elements. 
    * Quicksort can then recursively sort the sub-arrays.
    *
    * The steps are:
    * 
    * 1. Pick an element, called a pivot, from the array.
    * 
    * 2. Partitioning: reorder the array so that all elements with values 
    *    less than the pivot come before the pivot, while all elements with values 
    *    greater than the pivot come after it (equal values can go either way). 
    *    After this partitioning, the pivot is in its final position. 
    *    This is called the partition operation.
    *    
    * 3. Recursively apply the above steps to the sub-array of elements with smaller values
    *    and separately to the sub-array of elements with greater values.
    *
    * 
    * The base case of the recursion is arrays of size zero or one, which never need to be sorted.
    * 
    ************************************************************************
    * 
    * NOTE: How Insertion sort works.
    * 
    * Given an array:
    * 
    * | 16 | 8 | 10 | 4 | 7 | 9 | 13 |
    * 
    * Step 1.
    * Set i as start + 1 (start = 0, i + 1)
    * 
    * Step 2.
    * Set current as array[i], j as i (current = 8, j = 1)
    * 
    * Step 3.
    * While current > array[j - 1] set array[j] = array[j - 1] and j--
    * 
    * Step 4.
    * Set array[j] = current
    * 
    ************************************************************************/

    public static readonly Random Rand = new Random();
    public static readonly Stopwatch Sw = new Stopwatch();

    static void Main(string[] args)
    {
        // Step 1.
        // Create an array L with 100 elements, 
        // fill it with random numbers.

        int[] L = new int[100];
        FillArray(ref L, L.Length, 0, 100);

        Console.WriteLine("Array: ");
        PrintArray(L, L.Length);

        // Step 2.
        // Copy L into L1

        int[] L1 = CopyArray(L);

        // Step 3.
        // Sort L by combined quicksort.
        // Measure the time of execution.
        // Print sorted L.
        
        Sw.Start();

        QuicksortUpgrade(ref L, L.Length - 1);

        Sw.Stop();

        Console.WriteLine("\nL after sorting:");
        PrintArray(L, L.Length);
        Console.WriteLine("\nTime: " + Sw.Elapsed);

        Sw.Reset();

        // Step 4.
        // Sort L1 by ordinaty quicksort.
        // Measure the time.
        // Print sorted L1.

        Sw.Start();

        Quicksort(ref L1, L1.Length - 1);

        Sw.Stop();

        Console.WriteLine("\nL1 after sorting: ");
        PrintArray(L1, L1.Length);
        Console.WriteLine("\nTime: " + Sw.Elapsed);
    }

    public static void FillArray(ref int[] array, int elements, int min, int max)
    {
        for (int i = 0; i < elements; i++)
        {
            array[i] = Rand.Next(min, max);
        }
    }
    public static void PrintArray(int[] array, int elements)
    {
        for (int i = 0; i < elements - 1; i++)
        {
            Console.Write(array[i] + ", ");
        }

        Console.WriteLine(array[elements - 1]);
    }
    public static int[] CopyArray(int[] array)
    {
        int[] newArray = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            newArray[i] = array[i];
        }

        return newArray;
    }

    public static void Quicksort(ref int[] array, int elements)
    {
        Quicksort(ref array, 0, elements);
    }
    private static void Quicksort(ref int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int pivot = Partition(ref array, start, end);
        Quicksort(ref array, start, pivot - 1);
        Quicksort(ref array, pivot + 1, end);
    }
    private static int Partition(ref int[] array, int start, int end)
    {
        int temp;

        // Divides left and right subarrays
        int marker = start;

        // Set a random pivot
        int pivot = Rand.Next(start, end);

        temp = array[end];
        array[end] = array[pivot];
        array[pivot] = temp;

        // Take all elements from start to end
        for (int i = start; i <= end; i++)
        {
            // array[end] is pivot
            if (array[i] < array[end]) 
            {
                // Swap array[marker] and array[i].
                if (marker != i)
                {
                    temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                }               

                marker++;
            }
        }

        // Put pivot (array[end]) between left and right subarrays
        temp = array[marker];
        array[marker] = array[end];
        array[end] = temp;

        return marker;
    }

    public static void QuicksortUpgrade(ref int[] array, int elements)
    {
        QuicksortUpgrade(ref array, 0, elements);
    }
    private static void QuicksortUpgrade(ref int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        if (end - start < 10)
        {
            InsertionSort(ref array, start, end + 1);
        }
        else
        {
            int pivot = Partition(ref array, start, end);
            QuicksortUpgrade(ref array, start, pivot - 1);
            QuicksortUpgrade(ref array, pivot + 1, end);
        }
    }
    private static void InsertionSort(ref int[] array, int start, int end)
    {
        for (int i = start + 1; i < end; i++)
        {
            int current = array[i];
            int j = i;

            while (j > 0 && current < array[j - 1])
            {
                array[j] = array[j - 1];
                j--;
            }

            array[j] = current;
        }
    }
}

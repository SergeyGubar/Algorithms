using System;

class Program
{
   /************************************************************************
    * 
    * TASK    
    * 
    * Given a maxheap stored in an array.
    * Convert it into a minheap. 
    * Print the array before the operation and after it.
    * 
    ************************************************************************
    * 
    * NOTE: How to read a heap.
    * 
    * Given a maxheap:
    * 
    *            16
    *         (      )
    *        10      13
    *      (    )  (    )
    *     9     4  11   8 
    *   (   )  (
    *   2   1  3
    *   
    *   This heap could be represented as an array of 10 elements:
    *   
    *   | 16 | 10 | 13 | 9 | 4 | 11 | 8 | 2 | 1 | 3 |
    *   
    *   Where heap[0] - root,
    *   and childs of element heap[i] are heap[2i + 1] and heap[2i + 2]
    *   
    *   For example: heap[i] = heap[1] = 10
    *                heap[2i + 1] = heap[2*1 + 1] = heap[3] = 9
    *                heap[2i + 2] = heap[2*1 + 2] = heap[4] = 4 
    *  
    ************************************************************************/

    private static readonly Random Rand = new Random();

    static void Main(string[] args)
    {
        // Step 1.
        // Create a random maxheap.

        Console.Write("Enter the size of the heap: ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] heap = new int[size];

        FillArray(ref heap, size, 1, 100);

        Console.WriteLine("\nArray: ");
        PrintArray(heap, size);

        ConvertToMaxHeap(ref heap);

        Console.WriteLine("\nConverted to a maxheap: ");
        PrintArray(heap, size);

        // Step 2
        // Convert maxheap to a minheap.

        ConvertToMinHeap(ref heap);

        Console.WriteLine("\nConverted to a minheap: ");
        PrintArray(heap, size);

        Console.WriteLine();
        Console.ReadLine();
    }

    public static void FillArray(ref int[] array, int elemets, int min, int max)
    {
        for (int i = 0; i < elemets && i < array.Length; i++)
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

    public static void ConvertToMaxHeap(ref int[] array)
    {
        for (int i = array.Length / 2; i >= 0; i--)
        {
            HeapifyMax(i, ref array);
        }
    }
    public static void ConvertToMinHeap(ref int[] array)
    {
        for (int i = array.Length / 2; i >= 0; i--)
        {
            HeapifyMin(i, ref array);
        }
    }

    public static void HeapifyMax(int startPosition, ref int[] array, int size = -1)
    {
        // In Heapify we took 'startPosition' as a element,
        // from which we starter rebuilding our heep.
        // size - unsorted part of the array 
        // (or just how many items in array should we heapify

        if (size == -1)
            size = array.Length;

        while (true)
        {
            // Left child of our 'node'
            int leftChild = 2 * startPosition + 1;
            // Right child of our 'node'
            int rightChild = 2 * startPosition + 2;
            // Current largest child
            int largestChild = startPosition;

            // Check if left child is > largest child, set lc
            if (leftChild < size && array[leftChild] > array[largestChild])
                largestChild = leftChild;

            // Check if right child is > largest child, set lc
            if (rightChild < size && array[rightChild] > array[largestChild])
                largestChild = rightChild;

            // If our array is heap, break.
            if (largestChild == startPosition)
                break;

            // Swap last element with largest child;
            // Set startPosition  largest child.
            int temp = array[startPosition];
            array[startPosition] = array[largestChild];
            array[largestChild] = temp;
            startPosition = largestChild;
        }
    }
    public static void HeapifyMin(int startPosition, ref int[] array, int size = -1)
    {
        // In Heapify we took 'startPosition' as a element,
        // from which we starter rebuilding our heep.
        // size - unsorted part of the array 
        // (or just how many items in array should we heapify

        if (size == -1)
            size = array.Length;

        while (true)
        {
            // Left child of our 'node'
            int leftChild = 2 * startPosition + 1;
            // Right child of our 'node'
            int rightChild = 2 * startPosition + 2;
            // Current largest child
            int smallestChild = startPosition;

            // Check if left child is < smallest child, set lc
            if (leftChild < size && array[leftChild] < array[smallestChild])
                smallestChild = leftChild;

            // Check if right child is < smallest child, set lc
            if (rightChild < size && array[rightChild] < array[smallestChild])
                smallestChild = rightChild;

            // If our array is heap, break.
            if (smallestChild == startPosition)
                break;

            // Swap last element with smallest child;
            // Set startPosition to smallest child.
            int temp = array[startPosition];
            array[startPosition] = array[smallestChild];
            array[smallestChild] = temp;
            startPosition = smallestChild;
        }
    }
}

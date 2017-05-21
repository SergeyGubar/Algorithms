using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_Task_4
{
    class Program
    {
        /***************************************************************************
        TASK

        Given a maxheap of k elements stored in an array of n elements.
        One more element is added to maxheap. (always before the operation n-5 > k)
        Write a function that reconstructs a correct maxheap. 
        Print the array before the operation and after it.

        ****************************************************************************/

        private static readonly Random Rand = new Random();

        static void Main(string[] args)
        {
            // Step 1.
            // Build a maxheap of k elements.
            
            Console.Write("Enter heap size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] maxHeap = new int[size];

            Console.Write("Enter number of elements in heap: ");
            int elements = Convert.ToInt32(Console.ReadLine());

            FillArray(ref maxHeap, elements, 0, 50);

            Console.WriteLine("\nGiven array:");
            PrintArray(maxHeap, elements);

            ConvertToHeap(ref maxHeap);

            Console.WriteLine("\nConverted to a maxheap:");
            PrintArray(maxHeap, elements);

            // Step 2.
            // Add one more element to a maxheap.

            Console.Write("\nAdd one more element to the heap: ");
            int newElement = Convert.ToInt32(Console.ReadLine());

            AddElementToArray(ref maxHeap, ref elements, newElement);

            // Step 3.
            // Reconstruct a correct maxheap.

            Console.WriteLine("\nBefore correction:");
            PrintArray(maxHeap, elements);

            CorrectHeap(ref maxHeap, elements);

            Console.WriteLine("\nAfter correction:");
            PrintArray(maxHeap, elements);
        }

        public static void AddElementToArray(ref int[] array, ref int elements, int newElement)
        {
            if (elements == array.Length)
            { 
                Array.Resize(ref array, elements + 1);
            }

            array[elements] = newElement;
            elements++;
        }
        public static void FillArray(ref int[] array, int elemets, int min, int max)
        {
            for (int i = 0; i < elemets && i < array.Length; i++)
            {
                array[i] = Rand.Next(min, max);
            }
        }
        public static void ConvertToHeap(ref int[] array)
        {
            for (int i = array.Length / 2; i >= 0; i--)
            {
                Heapify(i, ref array);
            }       
        }
        public static void Heapify(int startPosition, ref int[] array, int size = -1)
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

                // Check if left child is > largest child, set lc
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
        public static void CorrectHeap(ref int[] heap, int elements)
        {
            int itemParent = (elements - 1) / 2;
            int i = elements - 1;

            while (i > 0 && heap[itemParent] < heap[i])
            {
                var temp = heap[i];
                heap[i] = heap[itemParent];
                heap[itemParent] = temp;

                i = itemParent;
                itemParent = (i - 1) / 2;
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
    }
}

/* Task 9
* Write a mergesort function that calls the function bubble sort for sorting sublists of the size less than 10. 
* 
* In main():
* - create int L[100] initialize it by random numbers, copy L into int L1[100]
* - sort L by your combined mergeksort, measure the time of execution, print sorted array L
* - process L1 by an ordinary mergesort, measure the time, print sorted L1.
*/

using System;
using System.Diagnostics;

namespace ConsoleApp1 {

    class Program {
        static void Main(string[] args) {
            Random random = new Random();
            int[] L = new int[100];
            int[] L1 = new int[100];
            for (int i = 0; i < 100; i++) {
                L[i] = random.Next(0, 100);
                L1[i] = L[i];
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            MergeKSort(L, 0, 99);
            sw.Stop();
            Console.WriteLine("Sorted by mergeksort: (in " + sw.Elapsed + ")");
            for (int i = 0; i < 100; i++) {
                Console.Write(L[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            sw.Reset();
            sw.Start();
            MergeSort(L1, 0, 99);
            sw.Stop();
            Console.WriteLine("Sorted by mergesort: (in " + sw.Elapsed + ")");
            for (int i = 0; i < 100; i++) {
                Console.Write(L[i] + " ");
            }
        }

        public static void MainMerge(int[] array, int left, int mid, int right) {
            int[] temp = new int[100];
            int i, 
                leftBound, 
                elementsCount, 
                newArrayPosition;

            leftBound = mid - 1;
            newArrayPosition = left;
            elementsCount = (right - left + 1);

            while (left <= leftBound && mid <= right) {
                if (array[left] <= array[mid])
                    temp[newArrayPosition++] = array[left++];
                else
                    temp[newArrayPosition++] = array[mid++];
            }

            while (left <= leftBound)
                temp[newArrayPosition++] = array[left++];

            while (mid <= right)
                temp[newArrayPosition++] = array[mid++];

            for (i = 0; i < elementsCount; i++) {
                array[right] = temp[right];
                right--;
            }
        }

        public static void MergeKSort(int[] array, int left, int right) {
            if (right - left >= 10) {
                int mid = (left + right) / 2;
                MergeKSort(array, left, mid);
                MergeKSort(array, mid + 1, right);

                MainMerge(array, left, mid + 1, right);
            } else {
                BubbleSort(array, left, right);
            }
        }

        public static void MergeSort(int[] array, int left, int right) {
            if (right > left) {
                int mid = (left + right) / 2;
                MergeKSort(array, left, mid);
                MergeKSort(array, mid + 1, right);

                MainMerge(array, left, mid + 1, right);
            }
        }

        public static void BubbleSort(int[] array, int left, int right) {
            for (int i = left; i < right; i++) {
                for (int j = left; j < right; j++) {
                    if (array[i] > array[i + 1]) {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
        }
    }
}

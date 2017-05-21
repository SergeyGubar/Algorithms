using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5ALGS
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LinkedSortedListTask
            //1
            LinkedSortedList list = new LinkedSortedList();
            Console.WriteLine("First list: ");
            list.AddItem(4);
            list.AddItem(6);
            list.AddItem(3);
            list.AddItem(5);
            list.AddItem(8);
            list.AddItem(7);
            list.Print();
            Console.WriteLine();
            LinkedSortedList list1 = new LinkedSortedList();
            Console.WriteLine("Second list: ");
            list1.AddItem(0);
            list1.AddItem(10);
            list1.Print();
            Console.WriteLine();
            list.Merge(list1);
            Console.WriteLine("Merged list: ");
            list.Print();
            Console.WriteLine();

            #endregion


            #region UnsortedLinkedListTask
            //2.Create a linked unsorted list, print it, sort it by bubble sort, print the result.
            LinkedUnsortedList list2 = new LinkedUnsortedList();
            list2.AddItem(4);
            list2.AddItem(8);
            list2.AddItem(11);
            list2.AddItem(3);
            list2.AddItem(0);
            Console.WriteLine("Unsorted list: ");
            list2.Print();
            Console.WriteLine();
            Console.WriteLine("After bubble sort: ");
            list2.BubbleSort();
            list2.Print();

            #endregion

            #region arrayTask

            //3.Given an array of integer numbers.Its two adjacent sections(from index F1 to
            //L1 and from index L1+1 to L2) are sorted in ascending order. Print the array.
            //It is necessary to merge them in ascending order into positions from F1 to 
            //L2 without using an extra array(only 1 extra variable is allowed).Print array after merging.


            int[] arr = { -4, 6, 7, 8, 12, -10, 13, 14 };
            PrintArray(arr);
            MergeAscending(arr,0,4,arr.Length-1);
            PrintArray(arr);
            #endregion


        }

        static void MergeAscending(int[] arr, int F1, int L1, int L2)
        {

            //F1 - начало отсортиванной первой части
            //L1 - конец первой отсортированной части
            //L1 + 1 - начало второй
            //L2 - конец второй
            for (int i = L1 + 1; i <= L2; i++)
            {
                for (int j = F1; j <= L1; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        
                        int temp = arr[i];
                        for (int k = L1; k >= j; k--)
                        {
                            arr[k + 1] = arr[k];
                        }
                        arr[j] = temp;
                        F1++;
                        L1++;
                        i++;
                    }

                }
            }     
        }
        

        

        static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}

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



        }
    }
}

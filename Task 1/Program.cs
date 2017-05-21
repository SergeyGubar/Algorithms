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
   

        }

    }
}

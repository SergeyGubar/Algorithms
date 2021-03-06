﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
        public Node(int data, Node next)
        {
            Data = data;
            Next = next;
        }
    }
    public class LinkedUnsortedList
    {
        public Node HeadNode;

        public int Length
        {
            get
            {
                int length = 0;
                Node current = HeadNode;
                while (current != null)
                {
                    length++;
                    current = current.Next;
                }
                return length;
            }
        }

        public LinkedUnsortedList(Node headNode)
        {
            HeadNode = headNode;
        }

        public LinkedUnsortedList()
        {
        }

        public bool IsEmpty()
        {
            return HeadNode == null;
        }

        public void AddItem(int data)
        {
            if (IsEmpty())
            {
                HeadNode = new Node(data);
            }
            else
            {
                Node current = HeadNode;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(data);
            }
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty, nothing to print :(");
            }
            Node current = HeadNode;
            while (current != null)
            {
                Console.Write($"{current.Data}->");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void BubbleSort()
        {
            Node current1 = HeadNode;
            while (current1 != null)
            {
                Node current2 = current1;
                while (current2 != null)
                {

                    if (current2.Data < current1.Data)
                    {
                        int temp = current2.Data;
                        current2.Data = current1.Data;
                        current1.Data = temp;

                    }
                    current2 = current2.Next;
                }
                current1 = current1.Next;
            }

        }

    }



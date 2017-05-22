using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    public class LinkedSortedList
    {
        public Node HeadNode;

        public LinkedSortedList(Node headNode)
        {
            HeadNode = headNode;
        }

        public LinkedSortedList()
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
            else if (data < HeadNode.Data)
            {
                Node node = new Node(data);
                node.Next = HeadNode;
                HeadNode = node;
            }
            else
            {
                Node current = HeadNode;
                while (current.Next != null && data > current.Next.Data)
                {
                    current = current.Next;
                }
                Node newNode = new Node(data);
                newNode.Next = current.Next;
                current.Next = newNode;
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
        public void Merge(LinkedSortedList anotherList)
        {
            Node currNode = anotherList.HeadNode;
            while (currNode != null)
            {
                this.AddItem(currNode.Data);
                currNode = currNode.Next;
            }
        }

    }



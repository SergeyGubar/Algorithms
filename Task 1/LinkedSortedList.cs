
using System;

namespace Lab5ALGS
{
    //    1.	Write a class LinkedSortedList that contains such public methods:
    //-	addItem(int)
    //-	printList()
    //-	MergeLinked(L1, L2) //It merges sorted linked lists L1 and L2 into L1.
    //-	constructor
    //In main():
    //-	 create 2 sorted linked lists
    //-	 print them
    //-	merge them
    //-	print the result.


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

    
}
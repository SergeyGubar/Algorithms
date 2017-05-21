namespace Lab5ALGS
{
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
}
# Algorithms

[How to use](HowToUse.md)

Lab 5

Tasks:

1. Write a class LinkedSortedList that contains such public methods:
   - addItem(int)
   - printList()
   - MergeLinked(L1, L2) (it merges sorted linked lists L1 and L2 into L1)
   - constructor
   
   In main():
   - create 2 sorted linked lists
   - print them
   - merge them
   - print the result. 

   [SOLUTION](Task%201/Program.cs)
   
2. Create a linked unsorted list, print it, sort it by bubble sort, print the result.
   
   [SOLUTION](Task%202/Program.cs)

3. Given an array of integer numbers. 
   Its two adjacent sections (from index F1 to L1 and from index L1+1 to L2) are sorted in ascending order. 
   Print the array.
   It is necessary to merge them in ascending order into positions from F1 to L2 
   without using an extra array (only 1 extra variable is allowed). 
   Print array after merging.
   
   [SOLUTION](Task%203/Program.cs)

4. Given a maxheap of k elements stored in an array of n elements.  
   One more element is added to maxheap.
   Write a function that reconstructs a correct maxheap. 
   Print the array before the operation and after it.

   [SOLUTION](Task%204/Program.cs)

5. Given a maxheap stored in an array. 
   Convert it into a minheap. 
   Pint the array before the operation and after it.
   
   [SOLUTION](Task%205/Program.cs)
   
6. Write a quicksort function that calls the function insertion sort for sorting sublists of the size less than 10. 
   In main():
   - create int L[100] initialize it by random numbers, copy L into int L1[100]
   - sort L by your combined quicksort, measure the time of execution, print sorted array L
   - process L1 by an ordinary quicksort, measure the time, print sorted L1. 

   [SOLUTION](Task%206/Program.cs)


7. Create a hash table of size 100 to keep integer keys. Resolve collisions by chaining. Define some hash function.
   In main():
   - Enter 60 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists. 
   - Enter 90 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists.

   [SOLUTION](Task%207/Program.cs)


8. Create a hash table of size 100 to keep integer keys. Resolve collisions by rehashing. Define some hash function and rehash function.
   In main():
   - Enter 60 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists.
   - Enter 90 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists.

   [SOLUTION](Task%208/Program.cs)

   
9. Write a mergesort function that calls the function bubble sort for sorting sublists of the size less than 10. 
   In main():
   - create int L[100] initialize it by random numbers,  copy L into int L1[100]
   - sort L by your combined mergeksort, measure the time of execution, print sorted array L
   - process L1 by an ordinary mergesort, measure the time, print sorted L1. 

10. Specify a non-directed non-complete graph of n vertices by an adjacency matrix. 
    Fill the matrix by random numbers. 
    Starting from some vertex, visit each vertex in depth-first sequence and print their numbers. 
    
   [SOLUTION](Task%2010/GraphUtils.java)

 
11. Specify a non-directed non-complete graph of n vertices by an adjacency matrix. 
    Fill the matrix by random numbers. 
    Assign colors to its vertices. 
   
   [SOLUTION](Task%2011/GraphUtils.java)

     
12. Specify a non-directed non-complete graph of n vertices by an adjacency matrix. 
    Fill the matrix by random numbers. 
    Starting from some vertex, visit each vertex in breadth-first sequence and print their numbers.
    
   [SOLUTION](Task%2012/GraphUtils.java)
   

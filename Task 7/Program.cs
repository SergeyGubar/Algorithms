/* Task 7
 * 
 * Create a hash table of size 100 to keep integer keys. Resolve collisions by chaining. 
 * Define some hash function. 
 * 
 * In main():
 *  - Enter 60 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists.
 *  - Enter 90 random numbers (0 < number < 450) into the table. Count collisions. Print linked lists.
*/

using System;

namespace ConsoleApp1 {

    /// <summary>
    /// Reresents hash table by chaining collision resolution using simple linked lists
    /// </summary>
    public class MyHashTable {
        // Hash table
        public MyHashTableItem[] Table;
        // Table size
        public int Size;

        public MyHashTable(int size) {
            Table = new MyHashTableItem[size];
            Size = size;
        }

        /// <summary>
        /// Generates hash by function key % Size
        /// </summary>
        /// <param name="key">Input key</param>
        /// <returns></returns>
        public int GetHash(int key) {
            return key % Size;
        }

        /// <summary>
        /// Adds key into table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key) {
            int hash = GetHash(key);

            if (Table[hash] == null) {
                Table[hash] = new MyHashTableItem(key);
                return;
            }

            while (Table[hash].Next != null) {
                Table[hash] = Table[hash].Next;
            }

            Table[hash].Next = new MyHashTableItem(key);
        }

        /// <summary>
        /// Get key from the table
        /// This is dummiest function I ever made
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public int Get(int key) {
            int hash = GetHash(key);

            while (Table[hash].Next != null && Table[hash].Key != key) {
                Table[hash] = Table[hash].Next;
            }
            if (Table[hash].Key == key) {
                return Table[hash].Key;
            }
            return -1;
        }

        /// <summary>
        /// Counts collision inside whole table
        /// </summary>
        /// <returns>Count of collisions</returns>
        public int CountCollisions() {
            int collisions = 0;
            for (int i = 0; i < Size; i++) {
                MyHashTableItem current = Table[i];
                if (current == null || current.Next == null) {
                    continue;
                } 
                while (current.Next != null) {
                    collisions++;
                    current = current.Next;
                }
            }
            return collisions;
        }

        /// <summary>
        /// Prints table in console
        /// </summary>
        public void PrintTable() {
            for (int i = 0; i < Size; i++) {
                Console.Write("[" + i + "]: {");
                MyHashTableItem current = Table[i];
                while (current != null) {
                    Console.Write(Table[i].Key);
                    if (current.Next != null) {
                        Console.Write(", ");
                    }
                    current = current.Next;
                }
                Console.Write("}");
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Represents item inside chaining hash table
    /// </summary>
    public class MyHashTableItem {
        public MyHashTableItem Next;
        public int Key;

        public MyHashTableItem(int key) {
            Key = key;
        }
    }

    class Program {
        static void Main(string[] args) {
            MyHashTable table = new MyHashTable(100);
            Random random = new Random();

            Console.WriteLine("60 random numbers: ");
            for (int i = 0; i < 60; i++) {
                int number = random.Next(1, 450);
                Console.Write(number + " ");
                table.Add(number);
            }
            Console.WriteLine();

            Console.WriteLine("Collisions: " + table.CountCollisions());

            Console.WriteLine("Table: ");
            table.PrintTable();

            Console.WriteLine();

            Console.WriteLine("90 random numbers: ");
            for (int i = 0; i < 90; i++) {
                int number = random.Next(1, 450);
                Console.Write(number + " ");
                table.Add(number);
            }
            Console.WriteLine();


            Console.WriteLine("Collisions: " + table.CountCollisions());

            Console.WriteLine("Table: ");
            table.PrintTable();
        }
    }
}

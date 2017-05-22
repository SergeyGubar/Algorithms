/* Task 8
 * 
 * Create a hash table of size 100 to keep integer keys. Resolve collisions by rehashing. 
 * Define some hash function and rehash function. 
 * 
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
    public class HashTable {
        // Hash table
        public HashItem[] Table;
        // Table size
        public int Size;
        public int Count;
        public int Collisions;

        public HashTable(int size) {
            Table = new HashItem[size];
            Size = size;
            Count = 0;
            Collisions = 0;
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
        /// Rehashing for collision resloving by linear probing
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns></returns>
        public int Rehash(int key) {
            if (key == Size - 1) {
                return 0;
            }
            return key + 1;
        }

        /// <summary>
        /// Adds key into table
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(int key) {
            if (Count == Size) {
                return;
            }
            int hash = GetHash(key);

            if (Table[hash] == null) {
                Table[hash] = new HashItem(key);
                return;
            }

            if (Table[hash] != null) {
                Collisions++;
            }

            while (Table[hash] != null) {
                Table[hash] = Table[Rehash(hash)];
                hash = Rehash(hash);
            }

            Table[hash] = new HashItem(key);
        }

        /// <summary>
        /// Prints table in console
        /// </summary>
        public void PrintTable() {
            for (int i = 0; i < Size; i++) {
                Console.Write("index: " + i + " key: ");
                HashItem current = Table[i];
                if (Table[i] != null)
                    Console.Write(Table[i].Key);
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// Represents item inside chaining hash table
    /// </summary>
    public class HashItem {
        public int Key;

        public HashItem(int key) {
            Key = key;
        }
    }

    class Program {
        static void Main(string[] args) {
            HashTable table = new HashTable(100);
            Random random = new Random();

            Console.WriteLine("60 random numbers: ");
            for (int i = 0; i < 60; i++) {
                int number = random.Next(1, 450);
                Console.Write(number + " ");
                table.Add(number);
            }
            Console.WriteLine();

            Console.WriteLine("Collisions: " + table.Collisions);

            Console.WriteLine("Table: ");
            table.PrintTable();

            Console.WriteLine();

            table = new HashTable(100);

            Console.WriteLine("90 random numbers: ");
            for (int i = 0; i < 90; i++) {
                int number = random.Next(1, 450);
                Console.Write(number + " ");
                table.Add(number);
            }
            Console.WriteLine();


            Console.WriteLine("Collisions: " + table.Collisions);

            Console.WriteLine("Table: ");
            table.PrintTable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            LofiList<int> list = new();
            list.Add(1);
            list.Add(2);
            foreach (int i in list)
                Console.WriteLine(i);
            Console.WriteLine();
            Console.WriteLine();


            LofiLinkedList<int> lll = new();
            lll.Add(0);
            lll.Add(1);
            lll.Add(2);
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            lll[1] = 3;
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine(lll.Count);
            lll.Remove(3);
            lll.Remove(4);
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            lll.Insert(0, 5);
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            lll.Insert(3, 6);
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine(lll.Count);

            int[] arr = new int[4];
            lll.CopyTo(arr, 0);

            lll.Clear();
            foreach (int i in lll)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine(lll.Count);

            
        }
    }
}

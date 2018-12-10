using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab18
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>( new int[]{ 1, 2, 3, 2, 2, 4, 5, 5, 7, 8, 4, 4, 1, 0, 10 } );
            list.PrintFrequency();
            list.RemoveAt(1);
            list.InsertAt(14,200);
            list.PrintReverse();
        }

    }
    public static class LinkedListExtensions
    {
        public static void PrintFrequency<T>(this LinkedList<T> list)
        {
            SortedDictionary<T, int> ItemCount = new SortedDictionary<T, int>();

            foreach (T data in list)
            {
                if (ItemCount.ContainsKey(data))
                {
                    ItemCount[data]++;
                }
                else
                {
                    ItemCount.Add(data, 1);
                }
            }

            foreach (KeyValuePair<T, int> res in ItemCount)
            {
                Console.WriteLine("[" + res.Key + "]" + ":" + res.Value);
            }
        }

        public static bool RemoveAt<T>(this LinkedList<T> list, int index)
        {
       
            if (list.ElementAt(index) != null)
            {
            
                LinkedListNode<T> node = list.First;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                list.Remove(node);

                return true;
            }
            else
            {
                return false;
            }
        }
        public static void PrintReverse<T>(this LinkedList<T> list)
        {
         
            foreach (T data in list.Reverse())
            {
                Console.WriteLine(data.ToString());
            }
        }
        public static bool InsertAt<T>(this LinkedList<T> list, int index, T data)
        {
            if (index <= list.Count && index >= 0)
            {
           
                if (index == 0)
                {
                    list.AddFirst(data);
                }
              
                else
                {
                    LinkedListNode<T> prevNode = list.First;
                    for (int i = 0; i < index - 1; i++)
                    {
                        prevNode = prevNode.Next;
                    }
                    list.AddAfter(prevNode, data);
                }
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}

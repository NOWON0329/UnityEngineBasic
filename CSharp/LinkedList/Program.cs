﻿using System;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<float> myLinkedList = new MyLinkedList<float>();
            myLinkedList.AddLast(1.0f);
            myLinkedList.AddLast(3.0f);
            myLinkedList.AddLast(6.5f);
            myLinkedList.AddLast(4.2f);
            Console.WriteLine($"is 1.0f exist? {myLinkedList.FindLast(1.0f) != null}");
            Console.WriteLine($"is 1.0f removed? {myLinkedList.RemoveLast(1.0f)}");
            Console.WriteLine($"count? {myLinkedList.Count}");


            MyLinkedList<float>.MyLinkedListEnum<float> enumerator
                = myLinkedList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Reset();
        }
    }
}

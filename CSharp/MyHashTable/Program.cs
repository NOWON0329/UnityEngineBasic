using System;
using System.Globalization;

namespace MyHashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashTable ht = new MyHashTable();

            ht.Add("철수", 90);
            ht.Add('A', "알파벳 A");
            ht.Add(1, 3.0f);
            //object (객체타입)
            //boxing : object로 변환하는 과정(object 타입으로 바꿔서 힙영역에다가 새로운 객체르 할당)
            //unboxing : object에서 원래 타입으로 변환하는 과정
            string tmp = (string)ht['A'];
            int score = (int)ht["철수"];

            MyHashTable<string, int> ht2 = new MyHashTable<string, int>();
            ht2.Add("철수", 90);
            ht2.Add("영희", 80);
        }
    }
}

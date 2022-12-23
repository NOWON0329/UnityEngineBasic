using System;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            arr[0] = 1;

            MyDynamicArray da = new MyDynamicArray();
            da.Add(1);
            Console.WriteLine(da.ToString());   
        }
    }
}

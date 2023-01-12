using System;

namespace SortArgolism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 4, 2, 5, 6, 9, 3, 0, 8, 7};
            //SortAlgorism.BubbleSort(arr);
            //SortAlgorism.SelectionSort(arr);
            SortAlgorism.InsertionSort(arr);
            for(int i = 0; i<arr.Length; i++)
            {
                Console.WriteLine($"{arr[i]}");
            }
        }
    }
}

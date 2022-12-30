using System;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[3];
            arr[0] = 1;
            int a = arr[0]; 
            MyDynamicArray da = new MyDynamicArray();
            da.Add(1);
            Console.WriteLine(da.ToString());
            da.Find(BiggerThan20);

            MyDynamicArray<double> daDouble = new MyDynamicArray<double>();
            daDouble.Add(3.0f);
            daDouble.Add(6.5f);
            daDouble.Add(4.2f);

            MyDynamicArray<double>.MyDynamicArrayEnum<double> enumerator
                = daDouble.GetEnumerator();

            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Reset();
        }
        public static bool BiggerThan20(int value)
        {
            return value > 20;
        }
    }
}

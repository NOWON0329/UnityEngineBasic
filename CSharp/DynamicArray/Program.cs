using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

            IEnumerator<double> enumerator = daDouble.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            enumerator.Reset();
            enumerator.Dispose();

            //using : Dispose() 호출을 보장하는 구문. IDisposable을 상속받은 객체만 인자로 줄 수 있다.
            MyDynamicArray<int> daInt = new MyDynamicArray<int>();
            using (IEnumerator<int> enumerator_int = daInt.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
                enumerator.Reset();
            }

            foreach (var item in daDouble)
            {

            }
 
            MyDynamicArray<double>.MyDynamicArrayEnum<double> enumerator2
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

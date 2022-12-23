using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class MyDynamicArray
    {
        //const 키워드
        //상수 키워드. const 키워드가 붙은 변수는 
        //초기화만 가능하며, 상수처럼 사용된다.
        private const int DefaultSize = 1;
        private int[] data = new int[DefaultSize];
        public int count;
        private int capacity
        {
            get
            {
                return data.Length;
            }
        }                                             

        public int this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        public void Add(int item)
        {
            if(count >= capacity)
            {
                int[] tmp = new int[capacity * 2];
                for(int i = 0; i<count; i++)
                {
                    tmp[i] = data[i];
                }
                data = tmp;
            }
            data[count++] = item;
        }

        public bool Contains(int target)
        {
            for(int i = 0; i<count; i++)
            {
                if (data[i] == target)
                    return true;
            }

            return false;
        }

        public int Find(Predicate<int> match)
        {
            for(int i = 0; i<count; i++)
            {
                if (match(data[i]))
                {
                    return data[i];
                }
            }
            //default 키워드
            //해당 타입의 고정값을 반환하는 키워드
            return default(int);
        }

        public bool Remove(int item)
        {
            int index = -1;
            for(int i = 0; i<count; i++)
            {
                if (data[i] == item)
                {
                    index = i;
                    break;
                }
            }

            for(int i = index; i<count; i++)
            {
                data[i] = data[i+1];
            }
            count--;
            return index >= 0;
        }

        public bool RemoveAt(int index)
        {
            if (index > count - 1)
                return false;
            for (int i = index; i < count; i++)
            {
                data[i] = data[i + 1];
            }
            count--;
            return true;
        }

        public void Clear()
        {
            //data = new int[DefaultSize];

            for(int i = 0; i<capacity; i++)
            {
                data[i] = default(int);
            }
        }
        //public static bool BiggerThan(int standard)
        //{
        //    return value > 20;
        //}
    }
}
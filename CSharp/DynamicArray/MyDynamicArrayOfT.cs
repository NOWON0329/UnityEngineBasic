using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    //Genetic (제네틱)
    //자료형을 일반화하는 문법
    //클래스/ 구조체/ 인터페이스 / 함수 등의 이름 뒤에 붙어서 정해지지 않은 타입에 대한 일반식을
    //정의할 때 사용한다.
    internal class MyDynamicArray<T>
    {
        //const 키워드
        //상수 키워드. const 키워드가 붙은 변수는 
        //초기화만 가능하며, 상수처럼 사용된다.
        private const int DefaultSize = 1;
        private T[] data = new T[DefaultSize];
        public int count;
        private int capacity
        {
            get
            {
                return data.Length;
            }
        }                                             

        public T this[int index]
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

        //삽입 알고리즘
        //일반적으로 0(1)
        //단, capacity가 모자랄때는 0(N)
        public void Add(T item)
        {
            if(count >= capacity)
            {
                T[] tmp = new T[(int)Math.Ceiling(Math.Log10(capacity)) + DefaultSize + 1];
                for(int i = 0; i<count; i++)
                {
                    tmp[i] = data[i];
                }
                data = tmp;
            }
            data[count++] = item;
        }

        //탐색 알고리즘
        //O(N)
        public bool Contains(T target)
        {
            for(int i = 0; i<count; i++)
            {
                if (Comparer<T>.Default.Compare(data[i], target) == 0)
                    return true;
            }

            return false;
        }

        public T Find(Predicate<T> match)
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
            return default(T);
        }

        //삭제 알고리즘
        //O(N)
        public bool Remove(T item)
        {
            int index = -1;
            for(int i = 0; i<count; i++)
            {
                if (Comparer<T>.Default.Compare(data[i], item) == 0)
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

        //인덱스 삭제 알고리즘
        //O(N)
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
                data[i] = default(T);
            }
        }

        public MyDynamicArrayEnum<T> GetEnumerator()
        {
            return new MyDynamicArrayEnum<T>(data);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        //열거자의 핵심멤버
        //current :열거된 자료구조에서 현재 가리키고 있는 자료 아이템
        //MoveNext() : 현재에서 그다음 아이템을 가리키도록 하는 함수
        //Reset() : 가리키는 인덱서를 초기화하는 함수
        public struct MyDynamicArrayEnum<K>
        {
            public K Current
            {
                get
                {
                    return data[index];
                }
            }
            private readonly K[] data;
            private int index;

            public MyDynamicArrayEnum(K[] origin)
            {
                data = origin;
                index = -1;
            }

            public bool MoveNext()
            {
                index++;
                return (index >= 0) && (index < data.Length);
            }
            public void Reset()
            {
                index = -1;
            }
            //IDispose
            //관리되지 않는 힙영역 (Unmanaged heap) 의 메모리를 해제하는 내용을 구현하는 함수
            public void Dispose()
            {

            }
        }
    }
}
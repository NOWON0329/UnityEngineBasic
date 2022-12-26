using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Node<T>
    {
        public T value;
        public Node<T> next;
        public Node<T> prev;

        public Node(T value)
        {
            this.value = value;
        }
    }
    internal class MyLinkedList<T>
    {
        public Node<T> first => _first;
        public Node<T> last => _last;
        private Node<T> _first, _last, _tmp1, _tmp2;

        public int Count
        {
            get
            {
                int count = 0;
                _tmp1 = _first;
                while(true)
                {
                    count++;
                    _tmp1 = _tmp1.next;
                }
                return count;
            }
        }
        //삽입 알고리즘
        //O(1)
        public void AddFirst(T value)
        {
            _tmp1 = new Node<T>(value);

            //노드가 현재 하나이상 존재한다.
            if(_first != null)
            {
                _tmp1.next = _first;
                _first.prev = _tmp1;
            }
            //노드가 하나도 없다면
            if(_last == null)
            {
                _last = _tmp1;
            }
            _first = _tmp1;
        }
        public void AddLast(T value)
        {
            _tmp1 = new Node<T>(value);
        
            if(_last != null)
            {
                _tmp1.prev = _last;
                _last.next = _tmp1;
            }
        
            if(_first == null)
            {
                _first = _tmp1;
            }
            _last = _tmp1;
        }
        public void AddBefore(Node<T> node, T value)
        {

        }
        public void AddAfter(Node<T> node, T value)
        {

        }
        public Node<T> Find(int value)
        {
            return null;
        }
        public Node<T> FindLast(int value)
        {
            return null;
        }
        public bool Remove(int value)
        {
            return false;
        }
        public bool RemoveLast(int value)
        {
            return false;
        }
    }
}

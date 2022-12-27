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
            _tmp1 = new Node<T>(value);

            if(node.prev != null)
            {
                node.prev.next = _tmp1;
                _tmp1.prev = node.prev;
            }
            else
            {
                _first = _tmp1;
            }

            node.prev = _tmp1;
            _tmp1.next = node;
        }
        public void AddAfter(Node<T> node, T value)
        {
            _tmp1 = new Node<T>(value);

            if(node.next != null)
            {
                node.next.prev = _tmp1;
                _tmp1.next = node.next;             
            }
            else
            {
                _last = _tmp1;
            }

            node.next = _tmp1;
            _tmp1.prev = node;
        }
        public Node<T> Find(T value)
        {
            _tmp1 = _first;
            while(_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(_tmp1.value, value) == 0)
                    return _tmp1;

                _tmp1 = _tmp1.next;
            }

            return null;
        }
        public Node<T> FindLast(T value)
        {
            _tmp1 = _last;
            while(_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(_tmp1.value, value) == 0)
                    return _tmp1;

                _tmp1 = _tmp1.prev;
            }
            return null;
        }

        public bool Remove(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            else
            {
                if (node.prev != null)
                    node.prev.next = node.next;
                else
                {
                    _first = node.next;
                }
                if (node.next != null)
                    node.next.prev = node.prev;
                else
                {
                    _last = node.prev;
                }

                return true;
            }
        }
        public bool Remove(T value)
        {
            return Remove(Find(value));
        }
        public bool RemoveLast(T value)
        {
            return false;
        }
    }
}

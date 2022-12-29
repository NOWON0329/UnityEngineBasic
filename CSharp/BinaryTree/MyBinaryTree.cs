using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Node<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;

        public Node(T value)
        {
            this.value = value;
        }
    }

    internal class MyBinaryTree<T>
    {
        //
        private Node<T> _root, _tmp1, _tmp2, _tmp3, _tmp4;

        //O(LogN)
        public void Add(T item)
        {
            if(_root != null)
            {
                _tmp1 = _root;
                while(_tmp1 != null)
                {
                    //내가 추가하려는 노드값이 현재 탐색 노드값보다 작은지
                    if (Comparer<T>.Default.Compare(item, _tmp1.value) < 0)
                    {
                        if(_tmp1.left != null)
                        {
                            _tmp1 = _tmp1.left;
                        }
                        else
                        {
                            _tmp1.left = new Node<T>(item);
                            return;
                        }
                    }
                    //내가 추가하려는 노드값이 현재 탐색 노드값보다 큰지
                    if (Comparer<T>.Default.Compare(item, _tmp1.value) > 0)
                    {
                        if(_tmp1.right != null)
                        {
                            _tmp1 = _tmp1.right;
                        }
                        else
                        {
                            _tmp1.right = new Node<T>(item);
                            return;
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"[MyBinaryTree] : {item} 은 이미 존재합니다. 중복 허용하지 않음.");
                    }
                }
            }
            else
            {
                _root = new Node<T>(item);
            }
        }
        //탐색 알고리즘
        public Node<T> Find(T item)
        {
            _tmp1 = _root;
            while (_tmp1 != null)
            {
                //작은지
                if (Comparer<T>.Default.Compare(item, _tmp1.value) < 0)
                {
                    _tmp1 = _tmp1.left;
                }
                //큰지
                else if (Comparer<T>.Default.Compare(item, _tmp1.value) > 0)
                {
                    _tmp1 = _tmp1.right;
                }
                //찾음
                else
                {
                    break;
                }
            }
            return _tmp1;
        }

        // 삭제 알고리즘
        // 삭제시 밸런싱 방법 :
        // 삭제한 노드의 오른쪽 자식의 가장왼쪽으로 leaf를 탐색하고
        // 더이상 왼쪽이 없더라도 오른쪽이 있으면 또 오른쪽 자식으로 가서 가장 왼쪽 leaf를 탐색하는 것을 반복 후
        // 마지막으로 찾은 leaf 노드를 원래 삭제하려던 노드의 오른쪽 자식 위치에다가 놓고 
        // 원래 삭제하려던 노드의 오른쪽 자식노드는 원래 삭제하려던 노드 위치에다가 놓는다.
        public bool Remove(T item)
        {
            if (_root == null)
                return false;

            _tmp1 = _root; //현재 탐색 노드
            _tmp2 = _root; //현재 탐색 노드의 부모노드
            int dir = 0; // 1: right, -1 : left
            bool success = false;

            //삭제하고자 하는 노드 탐색
            while (_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(item, _tmp1.value) < 0)
                {
                    _tmp2 = _tmp1;
                    _tmp1 = _tmp1.left;
                    dir = -1;
                }
                else if (Comparer<T>.Default.Compare(item, _tmp1.value) > 0)
                {
                    _tmp2 = _tmp1;
                    _tmp1 = _tmp1.right;
                    dir = 1;
                }
                else
                {
                    success = true;
                    break;
                }

            }
            if(success)
            {
                //자식이 없을 경우
                if (_tmp1.left == null && _tmp1.right == null)
                {
                    if (dir < 0)
                        _tmp2.left = null;
                    else if (dir > 0)
                        _tmp2.right = null;
                    else
                        throw new Exception($"[BinaryTree] : Wrong Child");
                    _tmp1 = null;
                }
                //왼쪽 자식만 있을 경우
                else if (_tmp1.left != null && _tmp1.right == null)
                {
                    if (dir < 0)
                        _tmp2.left = _tmp1.left;
                    else if (dir > 0)
                        _tmp2.right = _tmp1.left;
                    else
                        throw new Exception($"[BinaryTree] : Wrong Child");
                    _tmp1 = null;
                }
                //오른쪽 자식만 있을 경우
                else if (_tmp1.left == null && _tmp1.right != null)
                {
                    if (dir < 0)
                        _tmp2.left = _tmp1.right;
                    else if (dir > 0)
                        _tmp2.right = _tmp1.right;
                    else
                        throw new Exception($"[BinaryTree] : Wrong Child");
                    _tmp1 = null;
                }
                //자식 둘다 있을 경우
                else
                {
                    //트리 구조에 합당한 Leaf[노드(_tmp1을 대체할 수 있는 leaf 노드) 탐색
                    _tmp3 = _tmp1;

                    bool done = true;
                    while (_tmp3.right != null)
                    {
                        _tmp4 = _tmp3;
                        _tmp3 = _tmp3.right;
                        while (_tmp3.left != null)
                        {
                            _tmp4 = _tmp3;
                            _tmp3 = _tmp3.left;
                            done = false;
                        }

                        if (done)
                            break;
                    }

                    //tmp1 자리에 tmp3 대체
                    if (dir < 0)
                        _tmp2.left = _tmp3;
                    else if (dir > 0)
                        _tmp2.right = _tmp3;
                    else
                        throw new Exception($"[BinaryTree] : Wrong Child");

                    //기존 tmp1의 자식들을 tmp3의 자식으로 연결함
                    _tmp3.left = _tmp1.left;
                    _tmp3.right = _tmp1.right;
                    _tmp1 = _tmp2 = _tmp3 = _tmp4 = null;

                    //대체할 leaf 노드와 그 부모의 연결 끊음
                    if (Comparer<T>.Default.Compare(_tmp3.value, _tmp4.value) < 0)
                        _tmp4.left = null;
                    else if (Comparer<T>.Default.Compare(_tmp3.value, _tmp4.value) > 0)
                        _tmp4.right = null;
                    else
                        throw new Exception($"[BinaryTree] : Wrong Child");
                }
            }
            return success;
        }
    }
}

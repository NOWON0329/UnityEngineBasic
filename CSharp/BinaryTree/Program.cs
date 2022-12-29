using System;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree<int> tree = new MyBinaryTree<int>();

            tree.Add(5);
            tree.Add(3);
            tree.Add(4);
            tree.Add(7);
            tree.Add(6);
            tree.Add(8);
            tree.Add(9);
            tree.Add(10);
            Console.WriteLine(tree.root.value); //5
            Console.WriteLine(tree.root.left.value); //3
            Console.WriteLine(tree.root.left.right.value); //4
            Console.WriteLine(tree.root.right.value); //7
            Console.WriteLine(tree.root.right.right.value); // 8
            Console.WriteLine(tree.root.right.right.right.value); // 9

        }
    }
}

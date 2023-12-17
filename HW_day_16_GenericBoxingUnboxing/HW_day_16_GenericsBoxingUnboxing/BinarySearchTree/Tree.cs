using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Tree<T> where T : IComparable<T>
    {
        Node<T> root;
        Tree<T> tree;
        public Tree() 
        {  
            root = null;
            tree = null;
        }
        public void Insert(T value)
        {
            if (value != null)
            {
                if (root == null)
                    root = new Node<T>(value);
                else
                    InsertRecursive(root, value);
            }
        }

        public Node<T> Search(T value)
        {
             return SearchRecursive(root, value);
           
        }
        public void InsertRecursive(Node<T> curr, T value)
        {
            Node<T> n;
            if (curr == null)
                n =  new Node<T>(value);
            if (curr.value.CompareTo(value) > 0)
            {
                if (curr.left == null)
                    curr.left = new Node<T>(value);
                else
                    InsertRecursive(curr.left, value);
            }
            else
                if (curr.right == null)
                    curr.right = new Node<T>(value);
                else
                    InsertRecursive(curr.right, value);
        }

        public Node<T> SearchRecursive(Node<T> curr, T value)
        {
            if (curr == null || curr.value.CompareTo(value) == 0)
                return curr;
            else if (curr.value.CompareTo(value) > 0)
                return SearchRecursive(curr.left, value);
            else
                return SearchRecursive(curr.right, value);

        }

    }
}

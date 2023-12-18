using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBinarySearchTree
{
    class Node<T> where T : IComparable<T>
    {
        public T value;
        public Node<T> left;
        public Node<T> right;

        public Node(T v)
        {
            left = null;
            right = null;
            value = v;
        }
    }
}

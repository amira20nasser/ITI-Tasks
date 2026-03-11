using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
    internal class StackDoubleLinkedList<T> : DoubleLinkedList<T>
    {
        public void Push(T value)
        {
            AddLast(value);
        }

        public void Pop()
        {
            RemoveLast();
        }
        public Node<T> peak()
        {
            return Back();
        }
    }
}

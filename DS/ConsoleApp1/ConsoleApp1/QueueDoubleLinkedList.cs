using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class QueueDoubleLinkedList<T>:DoubleLinkedList<T>
    {
        public void Push(T value)
        {
            AddLast(value);
        }

        public void Pop()
        {
            RemoveFirst();
        }
        public Node<T> peak()
        {
            return Front();
        }
    }
}

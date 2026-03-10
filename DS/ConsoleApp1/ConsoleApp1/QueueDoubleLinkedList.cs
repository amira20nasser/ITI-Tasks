using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class QueueDoubleLinkedList<T>:DoubleLinkedList<T>
    {
        public void Push(T value)
        {
            AddFirst(value);
        }

        public void Pop()
        {
            RemoveFirst();
        }
    }
}

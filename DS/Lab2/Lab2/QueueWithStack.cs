using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    internal class QueueWithStack<T>
    {
        private StackArray<T> s1, s2;

        public QueueWithStack(int capacity)
        {
            s1 = new StackArray<T>(capacity);
            s2 = new StackArray<T>(capacity);
        }
        public void EnqueueWithStack(T Value)
        {
            s1.Push(Value);
        }

        public void DequeueWithStack()
        {
            if (s2.isEmpty())
            {
                while (!s1.isEmpty())
                {
                    s2.Push(s1.Peak());
                    s1.Pop();
                }
            }
            if (s2.isEmpty())
            {
                throw new Exception("Queue is already Empty");
            }
            s2.Pop();
        }

        public T Front()
        {
            if (s2.isEmpty())
            {
                while (!s1.isEmpty())
                {
                    s2.Push(s1.Peak());
                    s1.Pop();
                }
            }
            if (s2.isEmpty())
            {
                throw new Exception("Queue is already Empty");
            }
            return s2.Peak();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace Lab2
{
    internal class StackArray<T>
    {
        private int count;
        private T[] array;
       public StackArray(int capacity)
       {
            array = new T[capacity];
            count = 0;
       }

        public bool isEmpty() =>  count==0;
        public bool isFull() => count == array.Length;

        public void Push(T item)
        {
            if (isFull())
                throw new Exception($"The array is full couldn't add more max size {array.Length}");
            array[count++] = item;
        }
        public void Pop()
        {
            if (isEmpty())
                throw new Exception("The array is empty couldn't pop more");
            count--;
        }
        public T Peak()
        {
            return array[count-1];
        }
    }
}

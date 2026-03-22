using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Lab2
{
    internal class QueueArray<T>
    {
        private int count;
        private T[] array;
        private int front, back;
        public QueueArray(int capacity)
        {
            array = new T[capacity];
            count = 0;
            front = back = -1;
        }

        public bool isEmpty() => count == 0;
        public bool isFull() => count == array.Length;

        public void Enqueue(T item)
        {
            if (isFull())
                throw new Exception("The Queue is full couldn't add more");
            if (count == 0)
            {
                front = 0;
            }
            back = (back + 1) % array.Length;
            array[back] = item;
            count++;
        }
        public void Dequeue()
        {
            if (isEmpty())
                throw new Exception("The Queue is empty couldn't pop more");
            if (count == 1)
                front = back = -1;
            else
                front = (front + 1) % array.Length;
            count--;
        }
        public T Front()
        {
            if (isEmpty())
                throw new Exception("The Queue is empty couldn't pop more"); 
            return array[front];
        }
        
    }
}

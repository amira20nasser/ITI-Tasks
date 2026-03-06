using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab5ITI
{
    class DynamicQueue
    {
        int[] arr;
        int head, tail;
        int size;

        public DynamicQueue()
        {
            size = 5;
            head = tail = -1;
            arr = new int[size];
        }
        public DynamicQueue(int _size)
        {
            size = _size;
            head = tail = -1;
            arr = new int[size];
        }

        public void Push(int value)
        {

            if (!IsFull())
            {
                if (head == -1)
                {
                    // first element insert
                    head = 0;
                }
                tail = (tail + 1) % size;
                arr[tail] = value;

            }
            else
            {
                Console.WriteLine("FULL!!!");
            }
        }
        public int Pop()
        {
            int result = -123;

            if (head != tail)
            {
                result = arr[head];
                head = (head + 1) % size;
            }
            else
            {
                head = -1;
                tail = -1;
                Console.WriteLine("EMPTY!!!");
            }
            return result;
        }

        public bool IsFull() { return head == (tail + 1) % size; }
        public int getHead()
        {
            if (head != -1)
            {
                return arr[head];
            }
            return -1;

        }

        public int getTail()
        {
            if (tail != -1)
            {
                return arr[tail];
            }
            Console.WriteLine("The Array is Full");
            return -1;

        }
    }
}

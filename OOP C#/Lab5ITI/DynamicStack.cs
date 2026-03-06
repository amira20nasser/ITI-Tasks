using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5ITI
{
    class DynamicStack
    {
        int[] arr;
        int top;
        int size;

        public DynamicStack()
        {
            size = 5;
            top = 0;
            arr = new int[size];
        }
        public DynamicStack(int _size)
        {
            size = _size;
            top = 0;
            arr = new int[size];
        }

        #region Stack Functionalities
        public void Push(int value)
        {
            if (!IsFull())
            {
                arr[top] = value;
                top++;
            }
            else
            {
                Console.WriteLine("FULL!!!");
            }
        }
        public int Pop()
        {
            int result = -123;
            //if (tos != 0)
            if (!IsEmpty())
            {
                top--;
                result = arr[top];
                //return result;
            }
            else
            {
                Console.WriteLine("EMPTY!!!");
                //return -123;  //not effective
                //return result;

                //effective
                ///throw runtime error
            }
            return result;
        }

        public bool IsFull() { return top == size; }
        public bool IsEmpty() { return top == 0; }
        #endregion


        public static DynamicStack operator +(DynamicStack left, DynamicStack right)
        {
            DynamicStack result = new DynamicStack(left.size + right.size);
            for (int i = 0; i < left.top; i++)
            {
                //////
                result.Push(left.arr[i]);
            }
            for (int i = 0; i < right.top; i++)
            {
                /////
                result.Push(right.arr[i]);
            }
            return result;
        }

        public void Print()
        {
            for (int i = 0; i < top; i++)
            {
                //////
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}

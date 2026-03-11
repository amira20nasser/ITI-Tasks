using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ConsoleApp1
{
    internal class DoubleLinkedList<T>
    {
        private  int count ;
        private Node<T>head;
        private Node<T> tail;
        public DoubleLinkedList()
        {
            count = 0;
        }
        public Node<T> Front()
        {
            if (head == null)
            {
                return null;
            }
            return head;
        }
        public Node<T> Back()
        {
            if (tail == null)
            {
                return null;
            }
            return tail;
        }
       public bool IsEmpty()
       {
            return count == 0;
       }
        public int Count { get { return count; } }
        public void AddFirst(T data)
        { /// O(1)
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = tail = newNode;
            }
            else
            {
                head.previous = newNode;
                newNode.next = head;
                head = newNode;
            }
            count++;
        }

        public void AddLast(T data)
        {/// O(1)
            Node<T> newNode = new Node<T>(data);
            if (head == null) {
                head = tail = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.previous = tail;
                tail = newNode;
            }
            count++;
        }
        public void RemoveFirst()
        {
            // O(1)
            if(count == 0)
            {
                Console.WriteLine("There is no data");
                return;
            }
            else if(count == 1) {
                head = tail = null;
            }
            else
            {
                head = head.next;
            
                head.previous = null;
            }
            count--;
        }
        public void RemoveLast()
        {
            // O(1)
            if (count == 0)
            {
                Console.WriteLine("There is no data");
                return;
            }
            else if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.previous;
                tail.next = null;
            }
            count--;
        }
       
        public T? GetDataByIndex(int index)
        {
            // O(n)
            if (count == 0)
            {
                Console.WriteLine($"Empty List");
                return default;
            }
            if(index >= count)
            {
                Console.WriteLine($"Invalid Index there is only {count} elements");
                return default;
            }
            Node<T> current = head;
            for (int i = 0; i < index; i++) { 
                current = current.next;
            }
            return current.Data;
        }
        public void DeleteAt(int index)
        {
            // O(n)
            Node<T> current = head;
            if (count == 0)
            {
                Console.WriteLine($"Empty List");
                return;
            }
            if (index >= count)
            {
                Console.WriteLine($"Invalid Index there is only {count} elements");
                return;
            }
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            else if(index == count - 1)
            {
                RemoveLast();
                return;
            }
            for (int i = 0; i < index-1; i++)
            {
                current = current.next;
            }
            Node<T> d = current.next;
            current.next = d.next;
            d.next.previous = current;
            d.next = null;
            d.previous = null;
            count--;
        }

        public void Display()
        {
            // O(n) 
            if (head == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.next;
            }
            Console.WriteLine();
        }
        // search 
        public bool IsExistData(T data)
        {
            // best O(1) 
            // worst O(n)
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data is Employee emp && data is Employee target)
                {
                    if (emp.Id == target.Id)
                    {
                        return true;
                    }
                }
                current = current.next;
            }
            return false;
        }
        public void DeleteAll()
        {
           // Worst Case O(n) 
           // Best Case O(1)
            if (head == null)
            {
                Console.WriteLine("The list is already empty.");
                return;
            }

            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine($"Deleting {current.Data}");
                Node<T> next = current.next;
                current.next = null;
                current.previous = null;

                current = next;
            }
        }
    }
}

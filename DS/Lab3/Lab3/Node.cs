using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Node<T>
    {
       public T Data { get; set; }
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }
        public Node() {
            next = null;
            previous = null;
        }

        public Node(T data)
        {
            this.Data = data;
            next = null;
            previous = null;
        }
    }
}

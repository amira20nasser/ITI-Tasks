namespace Lab2
{
    internal class Program
    {
        public static string ReverseString(string s)
        {

            StackArray<char> stack = new StackArray<char>(s.Length);

            foreach(char c in s)
            {
              stack.Push(c);
            }
            s = "";
            while (!stack.isEmpty())
            {
                s += stack.Peak();
                stack.Pop();
            }
            return s;
        }

     
        public static bool CheckBalcncedParntheses(string s)
        {

            StackArray<char> stack = new StackArray<char>(s.Length);

            foreach (char c in s)
            {
                if(c=='(')
                    stack.Push(c);
                if(c==')'&& !stack.isEmpty()&& stack.Peak()=='(')
                    stack.Pop();
                else if(c==')')
                    stack.Push(c);
            }
           
            return stack.isEmpty();
        }

        static void Main(string[] args)
        {
            StackArray<int> arr = new StackArray<int>(10);
            arr.Push(1);
            arr.Push(2);
            arr.Push(3);
            arr.Push(4);
            arr.Push(5);
            arr.Push(6);
            arr.Pop();
            arr.Pop();
            arr.Pop();

            Console.WriteLine(arr.Peak());
            Console.WriteLine("=======================");
            QueueArray<int> arr1 = new QueueArray<int>(10);
            arr1.Enqueue(1);
            arr1.Enqueue(2);
            arr1.Enqueue(3);
            arr1.Enqueue(4);
            arr1.Enqueue(10);
            Console.WriteLine(arr1.Front());
            arr1.Dequeue();
            Console.WriteLine(arr1.Front());
            Console.WriteLine("=======================");
            string s = "hello";
            Console.WriteLine(ReverseString(s));
            Console.WriteLine("=======================");
            Console.WriteLine(CheckBalcncedParntheses("()(())()") ? "Balanced" : "Not Balanced");
            Console.WriteLine(CheckBalcncedParntheses("()(())()(") ? "Balanced" : "Not Balanced");
            Console.WriteLine("=======================");
            QueueWithStack<int> x = new QueueWithStack<int>(10);
            x.EnqueueWithStack(10);
            x.EnqueueWithStack(20);
            x.EnqueueWithStack(30);
            Console.WriteLine(x.Front());
            x.DequeueWithStack();
            Console.WriteLine(x.Front());




        }
    }
}

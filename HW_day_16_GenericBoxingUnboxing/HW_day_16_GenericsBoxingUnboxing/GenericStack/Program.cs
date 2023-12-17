namespace GenericStack
{
    class GenerateStack<T>
    {
        private Stack<T> stack;
        public GenerateStack()
        {
            stack = new Stack<T>();
        }

        public void MyPush(T item)
        {
            stack.Push(item);
        }

        public T MyPop()
        {
            if (stack.Count == 0)
                Console.WriteLine("Invalid");
            return stack.Pop();

        }
        public T MyPeek()
        {
            if (stack.Count == 0)
                Console.WriteLine("Invalid");
            return stack.Peek();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenerateStack<int> stack = new GenerateStack<int>();
            stack.MyPush(1);
            stack.MyPush(2);
            stack.MyPush(3);

            Console.WriteLine(stack.MyPop());
            Console.WriteLine(stack.MyPeek());
        }
    }
}
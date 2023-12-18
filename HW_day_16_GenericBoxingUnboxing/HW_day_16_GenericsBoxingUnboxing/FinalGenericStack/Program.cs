namespace FinalGenericStack
{

        class GenericStack<T>
        {
            private int top;
            private int size; // current size
            private T[] stack;
            private int capacity; // max capacity
            public GenericStack(int _capacity)
            {
                size = 0;
                stack = new T[_capacity];
                capacity = _capacity;
                top = -1;
            }

            public void MyPush(T item)
            {
                if (top + 1 < capacity)
                {
                    top++;
                    stack[top] = item;
                    size++;
                }
                else
                {
                    Console.WriteLine("Stack is full, can't add anymore elements");
                }
            }

            public void MyPop()
            {
                if (size > 0)
                {
                    top--;
                    size--;
                }
                else
                {
                    Console.WriteLine("Stack is empty, can't remove elements");
                }
            }
            public T MyPeek()
            {
                if (size != 0)
                {
                    return stack[top];
                }
                else
                {
                    Console.WriteLine("Stack is empty");
                    return default(T);
                }

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                GenericStack<int> stack = new GenericStack<int>(5);

                stack.MyPush(1);
                stack.MyPush(2);
                stack.MyPush(3);

                Console.WriteLine(stack.MyPeek());
                stack.MyPop();
                Console.WriteLine(stack.MyPeek());
            
        }
    }
}
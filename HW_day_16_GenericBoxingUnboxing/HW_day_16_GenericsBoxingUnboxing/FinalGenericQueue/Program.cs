namespace FinalGenericQueue
{

        class GenericQueue<T>
        {
            private int firstIndex;
            private int lastIndex;
            private int size; // current size
            private T[] queue;
            private int capacity; // max capacity

            public GenericQueue(int _capacity)
            {
                size = 0;
                queue = new T[_capacity];
                capacity = _capacity;
                firstIndex = 0;
                lastIndex = 0;
            }

            public void MyEnqueue(T item)
            {
                if (size == capacity || lastIndex == capacity)
                {
                    Console.WriteLine("Queue is full, can't add elements");
                }
                else
                {
                    queue[lastIndex] = item;
                    lastIndex++;
                    size++;
                }
            }

            public T MyDequeue()
            {
                if (size != 0)
                {
                    T dequeued = queue[firstIndex];

                    for (int i = 0; i < size - 1; i++)
                    {
                        queue[i] = queue[i + 1];
                    }
                    size--;
                    lastIndex--;
                    return dequeued;
                }
                Console.WriteLine("Queue is empty, nothing to return");
                return default(T);
            }

            public T MyPeek()
            {
                if (size != 0)
                {
                    return queue[firstIndex];
                }
                Console.WriteLine("Queue is empty, nothing to return");
                return default(T);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                GenericQueue<int> queue = new GenericQueue<int>(5);

                queue.MyEnqueue(1);
                queue.MyEnqueue(2);
                queue.MyEnqueue(3);

                Console.WriteLine(queue.MyPeek());
                Console.WriteLine(queue.MyDequeue());
                Console.WriteLine(queue.MyPeek());
            
        }
    }
}
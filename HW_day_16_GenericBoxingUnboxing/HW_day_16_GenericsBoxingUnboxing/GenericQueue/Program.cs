namespace GenericQueue
{
    public class GenericQueue<T>
    {
        private Queue<T> queue;

        public GenericQueue()
        {
            queue = new Queue<T>();
        }

        public void MyEnqueue(T element)
        {
            queue.Enqueue(element);
        }

        public T MyDequeue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Invalid");
            }
            return queue.Dequeue();

        }

        public T MyPeek()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Invalid");
            }

            return queue.Peek();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            GenericQueue<int> q = new GenericQueue<int>();

            q.MyEnqueue(1);
            q.MyEnqueue(2);
            q.MyEnqueue(3);

            Console.WriteLine(q.MyPeek());
            Console.WriteLine(q.MyDequeue());

        }
    }
}
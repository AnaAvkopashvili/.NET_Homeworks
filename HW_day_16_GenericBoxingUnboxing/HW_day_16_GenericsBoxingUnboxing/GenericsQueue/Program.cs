namespace GenericsQueue
{
    class Program<T>
    {
        public static T MyPeek<T>(Queue<T> queue)
        {
            return queue.Last();
        }
        static void Main(string[] args)
        {
            //Queue<int> q = new Queue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //Console.WriteLine(MyPeek(q).ToString());
            //foreach (var element in q)
            //    Console.WriteLine(element);
            Console.Write("aankndd");
        }
    }
}
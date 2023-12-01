namespace Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sum(13));
            Console.WriteLine(sumTail(13, 0));
        }
        static int sum(int n)
        {
            if (n == 0) 
                return 0;  
            else
                return n += sum(n - 1);
            
        }
        static int sumTail(int n, int acc)
        {
            if (n == 0)
                return acc;
            else 
                return sumTail(n - 1, acc + n);
        }
    }
}
namespace Practice_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(digits(999));
            Console.WriteLine(digitsTail(999, 1));
        }
        static int digits(int n) 
        {
            if (n / 10 == 0)
                return 1;
            else
                return (digits(n / 10) + 1);
        }

        static int digitsTail(int n, int acc)
        {
            if (n / 10 == 0)
                return acc;
            else
                return (digitsTail(n/10, acc + 1));
        }
    }
}
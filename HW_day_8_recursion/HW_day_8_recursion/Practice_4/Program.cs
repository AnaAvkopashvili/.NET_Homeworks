namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(power(2, 10));
            Console.WriteLine(powerTail(2, 10, 1));

        }
        static int power(int n, int degree)
        {
            if (degree == 0)
                return 1;
            else
                return n * power(n, degree - 1);
        }
        static int powerTail(int n, int degree, int acc)
        {
            if (degree == 0)
                return acc;
            else
                return powerTail(n, degree - 1, n * acc);
        }
    }
}
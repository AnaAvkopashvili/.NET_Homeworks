namespace HW_day_8_recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nums(13);
            NumsTail(13, 1);
        }
        static void Nums(int n) 
        {
            if (n == 0) 
                return;
            else
                Nums(n - 1);
            Console.Write(n + " ");
        }

        static void NumsTail(int n, int acc)
        {
            if (n == 0)
                return;
            else
                Console.Write(acc + " ");
            NumsTail(n - 1, acc + 1);
        }
    }
}
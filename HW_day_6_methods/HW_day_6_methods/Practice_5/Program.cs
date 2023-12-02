namespace Practice_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 4;
            int result = ArrFact(Array(), num);
            if (result == 0)
                Console.WriteLine("Number " + num + " was not found in the given array");
            else
                Console.WriteLine(result);
        }
        static int[] Array()
        {
            Console.Write("Enter size of an array: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter integer for index " + i + ": ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }
        static int factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static int ArrFact(int[] arr, int num)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] == num)
                {
                    return factorial(num);
                }
            }
            return 0;
        }
    }
}
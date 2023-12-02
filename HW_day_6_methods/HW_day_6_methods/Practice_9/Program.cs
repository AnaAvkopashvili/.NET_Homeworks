namespace Practice_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The product of array elements is "  + multiplication(1, 2, 3, 4));
        }
        static int multiplication(params int[] arr)
        {
            int result = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                result *= arr[i];
            }
            return result;
        }
    }
}
namespace number_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 4, 1, 2, 3, 7 };
            Console.WriteLine(dissapeared(array));
        }
        static int dissapeared(int[] array)
        {
            int sum = 0;
            for (int j = 0; j <= array.Length + 1; j++)
            {
                sum += j;
            }

            for (int i = 0; i < array.Length; i++)
            {
                sum -= array[i];
            }
            return sum;
        }
    }
}
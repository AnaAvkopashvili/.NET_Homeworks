namespace MultipleReturnValues
{
    internal class Program
    {
        static (int min, int max) minmax(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            var minmaxTuple = new Tuple<int, int>(min, max);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            return (min, max);
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 5, 10};
            Console.WriteLine(minmax(arr));
        }
    }
}
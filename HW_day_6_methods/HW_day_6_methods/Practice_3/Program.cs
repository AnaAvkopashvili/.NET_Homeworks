namespace Practice_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int n in MinMax(Array()))
                Console.Write(n + ", ");
            Console.Write("The minimum and maximum numbers in an array.");
        }
        static int[] Array()
        {
            Console.Write("Enter size of an array: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Enter integer for index " + i + ": ");
                arr[i] = int.Parse(Console.ReadLine()); ;
            }
            return arr;
        }
        static IEnumerable<int> MinMax(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            yield return min;
            yield return max;
        }
    }
}
namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arithmetic average of array is: " + Avg(Array()));
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
        static Double Avg(int[] arr)
        {
            int sum = 0;
            Double avg = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                avg = (double) sum / arr.Length; 
            }
            return avg;
        }

    }
}
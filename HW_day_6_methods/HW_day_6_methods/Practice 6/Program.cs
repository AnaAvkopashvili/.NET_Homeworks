namespace Practice_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(output(redundant(Array(), 'a'), 'a'));
        }
        static char[] Array()
        {
            Console.Write("Enter size of an array: ");
            int size = int.Parse(Console.ReadLine());
            char[] arr = new char[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter integer for index " + i + ": ");
                arr[i] = char.Parse(Console.ReadLine());
            }
            return arr;
        }
        static int redundant(char[] arr, char c)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == c)
                    counter++;
            }
            return counter;
        }
        static string output(int count, char c)
        {
            return "'" + c + "'" + " shegvxvda " + count + "-jer";
        }
    }
}
namespace Practice_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello World";
            display(CountWords(input));
        }
        static int CountWords(string s)
        {
            string[] arr = s.Split(' ');
            return arr.Length;
        }
        static void display(int result)
        {
            Console.WriteLine($"Number of words: {result}");
        }
    }
}
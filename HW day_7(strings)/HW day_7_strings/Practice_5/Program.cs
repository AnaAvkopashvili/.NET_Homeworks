namespace Practice_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello 1 !";
            display(NumberOfIntegers(s), NumberOfLetters(s), s);
        }
        static int NumberOfIntegers(string s)
        {
            int count = 0;
            foreach (char i in s)
            {
                if (Char.IsDigit(i))
                    count++;
            }
            return count;
        }
        static int NumberOfLetters(string s)
        {
            int count = 0;
            foreach (char i in s)
            {
                if (Char.IsLetter(i))
                    count++;
            }
            return count;
        }
        static void display(int numbers, int letters, string s)
        {
            int others = s.Length - numbers - letters;
            Console.WriteLine($" \"{s}\" -> Letters: {letters}, Numbers: {numbers}, Others: {others}");
        }
    }
}
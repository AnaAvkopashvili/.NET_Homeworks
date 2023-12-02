namespace Practice_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(isPalindrome("abba", 0));
            Console.WriteLine(isPalindromeTail("abba", 0, true));
        }
        static bool isPalindrome(string s, int index)
        {
            if (index > s.Length / 2)
                return true;
            else
                return ((s[index] == s[s.Length - index - 1]) && isPalindrome(s, index + 1));
        }
        static bool isPalindromeTail(string s, int index, bool acc)
        {
            if (index > s.Length / 2)
                return acc;
            else
                return isPalindromeTail(s, index + 1, acc && (s[index] == s[s.Length - index - 1]));
        }
    }
}

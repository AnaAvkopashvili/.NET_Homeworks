using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Practice_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello, world!";
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Vowel Count: " + VowelCount(input, 'c'));
            Console.WriteLine("Vowels: " + Vowels(input, 'c'));

        }
        static int VowelCount(string input, char idetifier = 'v')
        {
            char[] arr = { 'a', 'e', 'i', 'o', 'u' };
            int counter = 0;
            if (idetifier == 'v')
            {
                foreach (char s in input.ToLower())
                {
                    if (s >= 'a' && s <= 'z' && "aeiou".IndexOf(s) != -1)
                        counter++;
                }
            }
            else if (idetifier == 'c')
            {
                foreach (char s in input.ToLower())
                {
                    if (s >= 'a' && s <= 'z' && "aeiou".IndexOf(s) == -1)
                        counter++;
                }
            }
            return counter;

        }
        static string Vowels(string input, char idetifier)
        {
            char[] arr = { 'a', 'e', 'i', 'o', 'u' };
            StringBuilder sb = new StringBuilder();
            if (idetifier == 'v')
            {
                foreach (char s in input.ToLower())
                {
                   if (s >= 'a' && s <= 'z' && "aeiou".IndexOf(s) != -1)
                        sb.Append(s).Append(" ");
                }
            }
            else if (idetifier == 'c')
            {
                foreach (char s in input.ToLower())
                {
                   if (s >= 'a' && s <= 'z' && "aeiou".IndexOf(s) == -1)
                      sb.Append(s).Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}

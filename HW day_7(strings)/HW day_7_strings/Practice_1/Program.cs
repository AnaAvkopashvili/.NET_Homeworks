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
            Console.WriteLine("Vowel Count: " + VowelCount(input, vowels));
            Console.WriteLine("Vowels: " + Vowels(input, vowels));

        }
        static int VowelCount(string input, char[] arr)
        {
            int counter = 0;
            foreach (char s in input.ToLower())
            {
                foreach (char l in arr)
                {
                    if (s == l)
                        counter++;
                }
            }
            return counter;
        }
        static string Vowels(string input, char[] arr)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char s in input.ToLower())
            {
                foreach (char l in arr)
                {
                    if (s == l)
                        sb.Append(l).Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}
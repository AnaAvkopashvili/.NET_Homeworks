using System.Text;

namespace Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(reverse("Hello"));
        }
        static string reverse(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
    }
}
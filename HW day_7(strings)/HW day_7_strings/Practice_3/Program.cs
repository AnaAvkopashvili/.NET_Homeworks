using System.Text;

namespace Practice_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            Console.WriteLine(WithSpace(Console.ReadLine()));
        }
        static string WithSpace(string s)
        {
            char[] chars = s.ToCharArray();
            return string.Join(" ", chars);
        }
    }
}
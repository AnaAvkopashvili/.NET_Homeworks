using System.Text;

namespace number_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(binary(11));
        }
        static string binary(int n)
        {
            StringBuilder sb = new StringBuilder(); 
            int reminder = 0;
            while (n != 1)
            {
                reminder = n % 2;
                n /= 2;
                sb.Append(reminder);
            }
            string reverse = "";
            reverse = sb.Append("1").ToString();
            StringBuilder sb2 = new StringBuilder();
            for (int i = reverse.Length - 1; i >= 0; i--)
            {
                 sb2.Append(reverse[i]);
            }
            return sb2.ToString();
        }
    }
}
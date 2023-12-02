using System;

namespace Practice_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(multipliers(GetNumber()));
        }
        static int GetNumber()
        {
            Console.Write("Enter a positive number: ");
            int num = int.Parse(Console.ReadLine());    
            return num;
        }
        static string multipliers(int num)
        {
            int startNumber = num;
            string result = "";
            for (int i = 0; num != 0; i++)
            {
                int digits = 0;
                digits = num % 10;
                num /= 10;
                if (i == 0)
                    result = digits + " * " + "10^" + i + "  " + result;
                else
                    result = digits + " * " + "10^" + i + " + " + result;
            }
           return (startNumber + " = " + result);
        }
    }
}
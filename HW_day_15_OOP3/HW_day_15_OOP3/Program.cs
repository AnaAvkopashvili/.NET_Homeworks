using System;
using System.Net.Sockets;
using System.Text;

namespace HW_day_15_OOP3
{
    static class Program
    {
        // String manipulation:
        public static string ReversedExtention(this string input)
        {
            string rev = "";
            if(!string.IsNullOrEmpty(input))
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    rev += input[i];
                }
                return rev;
            }
            return "Invalid input";
        }


        public static int OccurrencesExtension(this string input, char c)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(input))
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == c)
                        count++;
                }
                return count;
            }
            Console.WriteLine("Invalid input");
            return 0;
        }


        public static bool StartsEndsExtension (this string input, string sub)
        {
           
            if (!string.IsNullOrEmpty(sub))
            {
                if (input.Substring(0, sub.Length) == sub || input.Substring((input.Length - sub.Length), sub.Length) == sub)
                    return true;
                else
                    return false;
            }
            Console.WriteLine("Invalid input");
            return false;
        }


        // Numeric operations:
        public static bool isEvenExtension(this int input)
        {
            if (input % 2 == 0)
                return true;
            else
                return false;
        }

        public static int AbsoluteExtension(this int input) 
        {
            if (input < 0)
                input = input * (-1);
            return input;
           
        }

        public static int NearestExtension(this int input, int multiple)
        {
            int result = 0;
            result = (input / multiple);
            if (input % multiple >= 5)
                result += 1;
            return result * multiple;
            
        }

        // Data structures
        public static int[] DuplicatesExtension(this int[] input)
        {
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (input[i] == input[j])
                    {
                        for (int k = j; k < length - 1; k++)
                        {
                            input[k] = input[k + 1];
                        }
                        length--;
                        j--;
                    }
                }
            }
            Array.Resize(ref input, length);
            return input;
        }

        public static bool SpecificExtension(this int[] input, int element)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (element == input[i])
                    return true;
            }
            return false;
        }

        public static int MaximumExtension(this int[] input)
        {
            int max = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > max)
                    max = input[i];
            }
            return max;
        }

        //Date and time
        public static string DateExtension(this DateTime input)
        {
            return $"{input.Day}/{input.Month}/{input.Year} {input.Hour}:{input.Minute}:{input.Second}:{input.Millisecond}";

        }

        public static bool DateRangeExtension(this DateTime input, DateTime start, DateTime end)
        {
            if (input >= start && input <= end)
                return true;
            return false;
        }

        public static int AgeExtension(this DateTime input)
        {
            int years = DateTime.Now.Year - input.Year;
            if (input.Month - DateTime.Now.Month > 0 || (input.Month == DateTime.Now.Month && input.Day - DateTime.Now.Day > 0))
                years -= 1;
            return years;
        }

        // Collections and enumerables:
        public static int[] MergeExtension(this int[] input, int[] input2)
        {
            int newLength = input.Length + input2.Length;
            int[] merged = new int[newLength];
            for (int i = 0; i < input.Length; i++)
            {
                merged[i] = input[i];
            }
            for (int j = 0; j < input2.Length; j++)
            {
                merged[input.Length + j] = input2[j];
            }
            return merged;
        }

        public static string SeperatorExtension(this int[] input, string separator)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(input[i].ToString());
                if (i != input.Length - 1)
                    sb.Append(separator);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello".ReversedExtention());
            //Console.WriteLine("ana".OccurrencesExtension('a'));
            //Console.WriteLine("Hello".StartsEndsExtension("Hel"));
            //Console.WriteLine(13131327.isEvenExtension());
            //Console.WriteLine((-123).AbsoluteExtension());
            //Console.WriteLine((10).NearestExtension(5));

            //int[] array = { 1, 100, 1, 3, 4, 8, 2, 8, 3,4, 2};
            //int[] array2 = { 10, 11, 12, 13 };

            //int[] lst = array.DuplicatesExtension();
            //foreach (int i in lst)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine(array.SpecificExtension(2));
            //Console.WriteLine(array.MaximumExtension());
            //Console.WriteLine(DateTime.Now.DateExtension());

            //DateTime startDate = new DateTime(2004, 12, 23); // Start date
            //DateTime endDate = new DateTime(2004, 12, 31); // End date

            //Console.WriteLine(DateTime.Now.DateRangeExtension(startDate, endDate));
            //Console.WriteLine(startDate.AgeExtension());

            //int[] result = array.MergeExtension(array2);
            //foreach (int i  in result)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine(array2.SeperatorExtension(" / "));
        }
    }
}
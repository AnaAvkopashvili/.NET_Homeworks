namespace HW_day_12_static
{
    static class MATH
    {
        public enum Statuses 
        {
            PowMustBeaPositiveOrZero,
            Success,
            SuccessCompare,
            EqualNums
        }
        static int Pow(int number, int power, out Statuses stat) 
        {
            if (power < 0) 
            {
                stat = Statuses.PowMustBeaPositiveOrZero;
                return 0;
            }
            if (power == 0)
            {
                stat = Statuses.Success;
                return 1;
            }
            else
                stat = Statuses.Success;
                return number * Pow(number, power - 1, out stat);
        }
        static int Min(int first, int second, out Statuses stat)
        {
            if (first < second)
            {
                stat = Statuses.SuccessCompare;
                return first;
            }
            else if (second < first)
            {
                stat = Statuses.SuccessCompare;
                return second;
            }
            else
            {
                stat = Statuses.EqualNums;
                return first;
            }
        }
        static int Max(int first, int second, out Statuses stat)
        {
            if (first > second)
            {
                stat = Statuses.SuccessCompare;
                return first;
            }
            else if (second > first)
            {
                stat = Statuses.SuccessCompare;
                return second;
            }
            else
            {
                stat = Statuses.EqualNums;
                return first;
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Enter a number for the power function: ");
                int num = int.Parse(Console.ReadLine());
                Console.Write("Enter a power: ");
                int pow = int.Parse(Console.ReadLine());
                Statuses stat;
                Console.WriteLine(MATH.Pow(num, pow, out stat) + " " + stat.ToString());

                Console.Write("Enter the first number for function Min: ");
                int minNum1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the second number for function Min: ");
                int minNum2 = int.Parse(Console.ReadLine());
                Console.WriteLine(MATH.Min(minNum1, minNum2, out stat) + " " + stat.ToString());

                Console.Write("Enter the first number for function Min: ");
                int maxNum1 = int.Parse(Console.ReadLine());
                Console.Write("Enter the second number for function Min: ");
                int maxNum2 = int.Parse(Console.ReadLine());
                Console.WriteLine(MATH.Max(maxNum1, maxNum2, out stat) + " " + stat.ToString());
            }
        }
    }
}

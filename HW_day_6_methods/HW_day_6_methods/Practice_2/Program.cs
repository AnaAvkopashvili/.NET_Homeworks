namespace Practice_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = 2; 
            int[] numbers = { 1, 3, 1230, 15, 13, 23, 98 };
            int result = sum(index, numbers);
            Console.WriteLine($"The sum of the digits of a number at index {index} is {result}");
        }
        static int sum(int index, params int[] nums)
        {
            if (index >= 0 && index < nums.Length)
            {
                int num = nums[index];
                int sum = 0;

                while (num != 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                return sum;
            }
            return 0;
        }
    }
}
namespace day_10_midterm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6,7,8 };
            ShowPairs(12, array);
        }
        static void ShowPairs(int number, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            { 
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (number == array[j] + array[i])
                    {
                        Console.WriteLine($"{i}, {j}"); 
                    }
                }
            }
        }
    }
}
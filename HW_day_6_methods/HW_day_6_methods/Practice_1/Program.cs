using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int index = 4;
        int[] numbers = { 1, 3, 4, 15, 13, 23, 98 };
        int result = indexed(index, numbers);
        Console.WriteLine($"Number at index {index} in the array is {result}");
    }
    static int indexed(int index, params int[] elements)
    {
        return elements[index];
    }
}
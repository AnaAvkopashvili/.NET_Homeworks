using System;

namespace Practice_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 = Array();
            int[,] matrix2 = Array();
            Console.WriteLine("Here is the sum of matrices:\n" + display(sum(matrix1, matrix2)));
        }
        
        static int[,] Array()
        {
            Console.Write("Enter row size of an array: ");
            int size1 = int.Parse(Console.ReadLine());
            Console.Write("Enter column size of an array: ");
            int size2 = int.Parse(Console.ReadLine());
            int[,] arr = new int[size1,size2];
            int[,] arr2 = new int[size1,size2];
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size1; j++)
                {
                    Console.Write("Enter integer for index " + i + "," + j + ": ");
                    arr[i,j] = int.Parse(Console.ReadLine());
                }
            }
            return arr;
        }
        static int[,] sum(int[,] arr1, int[,] arr2)
        {
            int size1 = arr1.GetLength(0);
            int size2 = arr1.GetLength(1);
            int[,] summed = new int[size1,size2];
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    summed[i,j] = arr1[i,j] + arr2[i,j];
                }
            }
            return summed;
        }
        static string display(int[,] summed) 
        {
            int size1 = summed.GetLength(0);
            int size2 = summed.GetLength(1);
            string result = "";
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    result += summed[i, j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
﻿Console.Write("Enter array size: ");
int size = int.Parse(Console.ReadLine());

int[] arr = new int[size];

for (int i = 0; i < size; i++)
{
    Console.Write("Enter number for index " + i + " : ");
    int index = int.Parse(Console.ReadLine());
    arr[i] = index;
}

Array.Reverse(arr);
Console.WriteLine("Here is your reversed array!");
foreach (int n in arr)
{
    Console.WriteLine(n);
}

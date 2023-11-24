Console.Write("Enter array size: ");
int size = int.Parse(Console.ReadLine());

int[] arr = new int[size];

for (int i = 0; i < size; i++)
{
    Console.Write("Enter number for index " + i + " : ");
    int index = int.Parse(Console.ReadLine());
    arr[i] = index;
}

int sum = 0;
foreach (int n in arr)
{
    sum += n;
}
Console.Write("Sum of array elements is: " + sum);

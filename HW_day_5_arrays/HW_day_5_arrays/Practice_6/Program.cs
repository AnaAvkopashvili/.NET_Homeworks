Console.Write("Enter row size: ");
int size1 = int.Parse(Console.ReadLine());
Console.Write("Enter column size: ");
int size2 = int.Parse(Console.ReadLine());

int[,] arr = new int[size1, size2];

for (int i = 0; i < size1; i++)
{
    for (int j = 0; j < size2; j++)
    {
        {
            Console.Write("Enter number for index " + i + "," + j + " : ");
            int index = int.Parse(Console.ReadLine());
            arr[i, j] = index;
        }
    }
}

for (int i = 0; i < size1; i++)
{
    for (int j = 0; j < size2; j++)
    {
        Console.Write(arr[i, j] + " ");
    }
    Console.WriteLine("");
}

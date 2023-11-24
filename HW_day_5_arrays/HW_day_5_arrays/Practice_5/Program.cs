Console.Write("Enter array size: ");
int size = int.Parse(Console.ReadLine());
int[] arr = new int[size];

for (int i = 0; i < size; i++)
{
    Console.Write("Enter number for index " + i + " : ");
    int index = int.Parse(Console.ReadLine());
    arr[i] = index;
}

for (int i = 0; i < size; i++)
{
    bool uniqe = true;

    for (int j = 0; j < size; j++)
    {
        if (arr[i] == arr[j] && i != j)
            uniqe = false;
    }
    if (uniqe)
       Console.WriteLine(arr[i]);
}
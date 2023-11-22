Console.Write("Enter row size: ");
int size1 = int.Parse(Console.ReadLine());
Console.Write("Enter column size: ");
int size2 = int.Parse(Console.ReadLine());

int[,] arr1 = new int[size1, size2];
int[,] arr2 = new int[size1, size2];

Console.WriteLine("Fill first matrix");
for (int i = 0; i < size1; i++)
{ 
    for (int j = 0; j < size2; j++)
    {
        {
            Console.Write("Enter number for index " + i + "," + j + " : ");
            int index = int.Parse(Console.ReadLine());
            arr1[i, j] = index;
        }
    }
 }

Console.WriteLine("Fill second matrix");

for (int i = 0; i <size1; i++)
{
    for (int j = 0; j < size2; j++)
    {
        {
            Console.Write("Enter number for index " + i + "," + j + " : ");
            int index = int.Parse(Console.ReadLine());
            arr2[i, j] = index;
        }
    }
}

Console.WriteLine("Here is the sum of 2 matrices");
for (int i = 0; i < size1; i++)
{
    for (int j = 0; j < size2;j++)
    {
        Console.Write(arr1[i, j] + arr2[i, j] + " "); 
    }
    Console.WriteLine("");
}




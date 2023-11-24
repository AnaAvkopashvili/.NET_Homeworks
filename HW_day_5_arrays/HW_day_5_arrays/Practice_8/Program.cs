//jagged array
int[][] jarr = new int[8][];

for (int i = 0; i < jarr.Length; i++)
{
    jarr[i] = new int[8];
    for (int j = 0; j < jarr[i].Length; j++)
    {
        if (i < j)
            jarr[i][j] = 1;
        else
            jarr[i][j] = 0;
    }
}

Console.WriteLine("First picture: ");
for (int i = 0; i < jarr.Length; i++)
{
    for (int j = 0; j < jarr[i].Length; j++)
    {
        Console.Write(jarr[i][j] + " ");
    }
    Console.WriteLine();
}


for (int i = 0; i < jarr.Length; i++)
{
    jarr[i] = new int[8];
    for (int j = 0; j < jarr[i].Length; j++)
    {
        if (i + j > 7)
            jarr[i][j] = 1;
        else
            jarr[i][j] = 0;
    }
}

Console.WriteLine("Second picture: ");
for (int i = 0; i < jarr.Length; i++)
{
    for (int j = 0; j < jarr[i].Length; j++)
    {
        Console.Write(jarr[i][j] + " ");
    }
    Console.WriteLine();
}



//multidimentional array
int[,] arr = new int[8, 8];

for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        {
            if (i < j)
                arr[i, j] = 1;
            else
                arr[i, j] = 0;
        }
    }
}

Console.WriteLine("First picture: ");

for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write(arr[i, j] + " ");
    }
    Console.WriteLine("");
}



for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        {
            if (i + j > 7)
                arr[j, i] = 1;
            else
                arr[i, j] = 0;
        }
    }
}


Console.WriteLine("Second picture: ");

for (int i = 0; i < arr.GetLength(0); i++)
{
    for (int j = 0; j < arr.GetLength(1); j++)
    {
        Console.Write(arr[i, j] + " ");
    }
    Console.WriteLine("");
}






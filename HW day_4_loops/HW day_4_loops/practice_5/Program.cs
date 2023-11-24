//Practice_5
Console.Write("Enter a number of rows of Floyd's triangle to be printed: ");
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < i; j++)
    {
        if ((j % 2 == 1 && i % 2 == 0) || (j % 2 == 0 && i % 2 == 1))
        {
            Console.Write("0");
        }
        else
        {
            Console.Write("1");
        }
    }
    Console.WriteLine("1"); 
}
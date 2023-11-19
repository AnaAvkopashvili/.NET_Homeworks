//Practice_7
Console.Write("Enter a number: ");
int number = int.Parse(Console.ReadLine());
int n1 = 0;
int n2 = 1;
int result = 0;
Console.Write(n1 + "  ");
    for (int i = 0; i < number; i++)
{
    n1 = result;
    result = n1 + n2;
    Console.Write(result + "  ");
    n2 = n1;
}
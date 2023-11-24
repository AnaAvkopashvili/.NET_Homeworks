//Practice_3
Console.WriteLine("Enter a number: ");
int number = int.Parse(Console.ReadLine());

for (int i = 1; i <= number; i++)
{
    Console.WriteLine(i + " cubed is " + Math.Pow(i, 3));
}
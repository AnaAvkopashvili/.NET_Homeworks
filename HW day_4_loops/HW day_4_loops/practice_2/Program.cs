//Practice_2
Console.WriteLine("Enter a number: ");
int number = int.Parse(Console.ReadLine());
int counter = 0;

for (int i = 0; i <= number; i++)
{
    counter += i;
}
Console.WriteLine("Sum from 1 to " + number + " is " + counter);
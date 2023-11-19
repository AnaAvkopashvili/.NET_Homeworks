//Practice_4
Console.WriteLine("Enter a number: ");
int number = int.Parse(Console.ReadLine());
int counter = 0;

for (int i = 0; i <= number; i++)
{
    if (i % 2 == 1)
    {
        counter += i;
    }
}
Console.WriteLine("Sum of odd numbers from 1 to " + number + " is " + counter);
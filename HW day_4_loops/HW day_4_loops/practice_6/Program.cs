//Practice_6
Console.WriteLine("Enter a number: ");
int number = int.Parse(Console.ReadLine());
string result = "divisors of " + number + " are: ";

for (int i = 1; i <= number; i++)
{
    if (number % i == 0)
    {
        result += i + " ";
    }
}
Console.WriteLine(result);
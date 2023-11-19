//practice_8
Console.Write("Enter a number: ");
int n = int.Parse(Console.ReadLine());
string result = "";

while (n >= 1)
{
    if (n % 2 == 0)
    {
        result = "0" + result;
    }
    else
    {
        result = "1" + result;
    }
    n /= 2;
}
Console.Write(result);

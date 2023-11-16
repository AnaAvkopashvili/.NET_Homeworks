//N1
//Console.WriteLine("Enter integer number :");
//string input = Console.ReadLine();
//int number = Convert.ToInt32(input);
//if (number % 2 == 1)
//{
//    Console.WriteLine("Entered number " + number + " is odd");
//}
//else
//{
//    Console.WriteLine("Entered number " + number + " is even");
//}




//2
//Console.WriteLine("Enter first number: ");
//string input1 = Console.ReadLine();
//int A = int.Parse(input1);

//Console.WriteLine("Enter second number: ");
//string input2 = Console.ReadLine();
//int B = int.Parse(input2);

//Console.WriteLine("Enter third number: ");
//string input3 = Console.ReadLine();
//int C = int.Parse(input3);

//if (A + B > C && B + C > A && A + C > B)
//{
//    Console.WriteLine("This should be a triangle!");
//}
//else
//{
//    Console.WriteLine("This should NOT be a triangle!");
//}





//N3
//Console.WriteLine("Enter number: ");
//string input = Console.ReadLine();
//int n = int.Parse(input);
//int.TryParse(input, out int m);
//Console.WriteLine("The pow of the entered number is: " + Math.Pow(n, 2));





//N4
//Console.WriteLine("enter your birth year: ");
//string input = Console.ReadLine();
//int year = int.Parse(input);
//int reminder = year % 12;

//string result = reminder switch
//{
//    0 => "monkey",
//    1 => "rooster",
//    2 => "dog",
//    3 => "pig",
//    4 => "rat",
//    5 => "ox",
//    6 => "tiger",
//    7 => "rabbit",
//    8 => "dragon",
//    9 => "snake",
//    10 => "horse",
//    11 => "goat"
//};

//Console.WriteLine(year + " was " + result + " year");





//N5
//without using dictionaries, loops or methods
Console.WriteLine("Enter your day of birth: ");
string input1 = Console.ReadLine();
int day = int.Parse(input1);
Console.WriteLine("Enter your month of birth: ");
string month = Console.ReadLine().ToLower();

if ((month == "march" && day >= 21) || (month == "april" && day <= 19))
{
    Console.WriteLine(day + " " + month + " is " + "Aries");
}
else if ((month == "april" && day >= 20) || (month == "may" && day <= 20))
{
    Console.WriteLine(day + " " + month + " is " + "Taurus");
}
else if ((month == "may" && day >= 21) || (month == "june" && day <= 20))
{
    Console.WriteLine(day + " " + month + " is " + "Gemini");
}
else if ((month == "june" && day >= 21) || (month == "july" && day <= 22))
{
    Console.WriteLine(day + " " + month + " is " + "Cancer");
}
else if ((month == "july" && day >= 23) || (month == "august" && day <= 22))
{
    Console.WriteLine(day + " " + month + " is " + "Leo");
}
else if ((month == "august" && day >= 23) || (month == "september" && day <= 22))
{
    Console.WriteLine(day + " " + month + " is " + "Virgo");
}
else if ((month == "september" && day >= 23) || (month == "october" && day <= 22))
{
    Console.WriteLine(day + " " + month + " is " + "Libra");
}
else if ((month == "october" && day >= 23) || (month == "november" && day <= 21))
{
    Console.WriteLine(day + " " + month + " is " + "Scorpio");
}
else if ((month == "november" && day >= 22) || (month == "december" && day <= 21))
{
    Console.WriteLine(day + " " + month + " is " + "Sagittarius");
}
else if ((month == "december" && day >= 22) || (month == "january" && day <= 19))
{
    Console.WriteLine(day + " " + month + " is " + "Capricorn");
}
else if ((month == "january" && day >= 20) || (month == "february" && day <= 18))
{
    Console.WriteLine(day + " " + month + " is " + "Aquarius");
}
else
{
    Console.WriteLine(day + " " + month + " is " + "Pisces");
}

//N1(a)
//int a = 5;
//int b = 7;

//int temp;
//temp = a;
//a = b;
//b = temp;

//Console.WriteLine("a: "+ a);
//Console.WriteLine("b: " + b);

//(b)
//a = a + b;  //a=12
//b = a - b; //b= 5
//a = a - b; //a=5


//Console.WriteLine("a: " + a);
//Console.WriteLine("b: " + b);


//N2
Console.WriteLine("Enter year: ");
string input = Console.ReadLine();
int year = int.Parse(input);

bool result = ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0));
Console.WriteLine(result);

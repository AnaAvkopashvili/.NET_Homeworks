namespace number_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To turn off program type \"exit\" otherwise enter the directory path");
            string mainDir = "C: \\Users\\Kiu - Student\\Desktop";
            files(mainDir);
        }
        static void files(string input)
        {
            if (input == "exit")
                return;

            if (Directory.Exists(input))
                Console.WriteLine($"The directory {input} does not exist!");
            else
            {
                Console.WriteLine(Directory.GetFiles(input));
                //files(Directory.GetDirectories(input));
            }
        }
    }
}


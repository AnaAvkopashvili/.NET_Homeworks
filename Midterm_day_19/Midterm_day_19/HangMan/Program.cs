namespace HangMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Words words = new Words();
            string randomWord = words.GetWord();
            HangMan hangman = new HangMan(randomWord);
            while (true) 
            {

                Console.WriteLine("Word to be guessed is: ");
                hangman.Display();
                try
                {
                    Console.WriteLine("Enter a letter: ");
                    string input = Console.ReadLine();
                    char guessedLetter = char.Parse(input);
                    hangman.Guess(guessedLetter);
                    if (hangman.Win())
                        break;
                }
                catch
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
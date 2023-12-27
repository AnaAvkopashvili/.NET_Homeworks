using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class HangMan
    {
        private string word;
        private int countWarnings;
        private List<char> guessed;

        public HangMan(string _word)
        {
            word = _word.ToLower();
            countWarnings = 0;
            guessed = new List<char>();

        }
        public void Display()
        {
            foreach (char c in word)
            {
                if (guessed.Contains(c))
                    Console.Write(c + " ");
                else
                    Console.Write(" _ ");
            }
        }

        public void Guess(char letter)
        {
            letter = char.ToLower(letter);
            if (guessed.Contains(letter))
                Console.WriteLine("already guessed");
            if (!word.Contains(letter))
            {
                countWarnings++;
                if (countWarnings == 1)
                {
                    Console.WriteLine("Oops Head on Hanger");
                }
                else if (countWarnings == 2)
                {
                    Console.WriteLine("Oops Body on Hanger");
                }
                else if (countWarnings == 3)
                {
                    Console.WriteLine("Oops first hand on Hanger");
                }
                else if (countWarnings == 4)
                {
                    Console.WriteLine("Oops second hand on Hanger");
                }
                else if (countWarnings == 5)
                {
                    Console.WriteLine("Oops first leg on Hanger");
                }
                else if (countWarnings == 6)
                {
                    Console.WriteLine("Oops second leg on Hanger");
                    Console.WriteLine("You lose!");
                }
            }
            else
            {
                guessed.Add(letter);
            }
        }
        public bool Win()
        { 
            foreach (char c in word)
            {
                if (!guessed.Contains(c))
                {
                    return false;
                }
                
            }
            Console.WriteLine("You win!");
            return true;
        }
    }
}

using System.Security.Cryptography.X509Certificates;

namespace HW_day_21_ReflectionAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Kiu-Student\\Desktop\\Tests.txt";
            if (File.Exists(path))
            {
                Console.WriteLine("Choose: (Enter only numbers) \n 1) Start Test " +
                        "\n 2) Add Test.");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        using (StreamReader sr = new StreamReader(path))
                        {
                            Console.WriteLine("Starting test..");
                            string[] lines = File.ReadAllLines(path);
                            int score = 0;
                            int questionCount = 0;
                            foreach (string l in lines)
                            {
                                questionCount++;
                                string correct = "";
                                String[] str = l.Split('|');
                                for (int i = 0; i < str.Length; i++)
                                {
                                    if (str[i].EndsWith("*"))
                                    {
                                        correct = str[i].Replace("*", "");
                                        break;
                                    }
                                }
                                str = l.Replace("*", "").Split('|');
                                foreach (string item in str)
                                {
                                    Console.WriteLine(item);
                                }
                                Console.WriteLine("Please enter the answer (Enter char): ");

                                char userAnswer = char.Parse(Console.ReadLine());

                                char correctChar = correct.First();
                                if (userAnswer.Equals(correctChar))
                                {
                                    Console.WriteLine("Correct Answer!");
                                    score++;
                                }
                                else
                                {
                                    Console.WriteLine("The correct answer is " + correctChar);
                                }
                            }
                            Console.WriteLine($"Your result is: {score}/{questionCount}");
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            Console.WriteLine("Enter the question: ");
                            string question = Console.ReadLine();
                            Console.WriteLine("Enter 4 answers separating Enter button, if the answer is " +
                                "correct select it with ‘*’ symbol at the end.");
                            List<string> answers = new List<string>();
                            for (int i = 1; i <= 4; i++)
                            {
                                Console.Write($"Enter answer {i}: ");
                                answers.Add(Console.ReadLine());
                            }
                            string newTest = $"{question}|{string.Join("|", answers)}";
                            sw.WriteLine(newTest);
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}

using System;
using System.IO;
using System.Threading;

namespace CyberSecurityChatBot.Services
{
    public class ConsoleUIService
    {
        public void SetupConsole()
        {
            Console.Title = "Cybersecurity Awareness ChatBot";
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayHeader(string filePath)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            ShowDivider();
            Console.WriteLine("      Kwena Mokoena's CYBERSECURITY AWARENESS CHATBOT");
            ShowDivider();
            Console.WriteLine();

            if (File.Exists(filePath))
            {
                string asciiArt = File.ReadAllText(filePath);
                Console.WriteLine(asciiArt);
            }
            else
            {
                Console.WriteLine("               [ SECURITY BOT ACTIVE ]");
                Console.WriteLine("                    ______________");
                Console.WriteLine("                   |  ________   |");
                Console.WriteLine("                   | |  LOCK  |  |");
                Console.WriteLine("                   | |________|  |");
                Console.WriteLine("                   |_____________|");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("       Stay alert. Stay secure. Stay safe online.");
            Console.ResetColor();
            Console.WriteLine();
        }

        public string PromptForName()
        {
            string? name;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your name to begin: ");
                Console.ResetColor();

                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowErrorMessage("Name cannot be empty. Please enter your name.");
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void ShowWelcomeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeText($"Hello, {userName}! Welcome to the Cybersecurity Awareness ChatBot.");
            TypeText("I am here to help you learn how to stay safe online.");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You can ask me about:");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" - Password safety");
            Console.WriteLine(" - Phishing scams");
            Console.WriteLine(" - Safe browsing");
            Console.WriteLine(" - Suspicious links");
            Console.WriteLine(" - My purpose");
            Console.WriteLine(" - How I am doing");
            Console.WriteLine();
            Console.WriteLine("Type 'exit', 'quit', or 'bye' to close the chatbot.");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeText($"Bot: {message}");
            Console.ResetColor();
        }

        public void ShowUserPrompt()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You: ");
            Console.ResetColor();
        }

        public void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {message}");
            Console.ResetColor();
        }

        public void ShowExitMessage(string userName)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeText($"Goodbye, {userName}. Thank you for using the Cybersecurity Awareness ChatBot.");
            TypeText("Remember: Think before you click.");
            Console.ResetColor();
        }

        public void ShowDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("========================================================");
            Console.ResetColor();
        }

        public void ShowSectionTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine($"========== {title.ToUpper()} ==========");
            Console.ResetColor();
        }

        public void TypeText(string text, int delay = 15)
        {
            foreach (char character in text)
            {
                Console.Write(character);
                Thread.Sleep(delay);
            }

            Console.WriteLine();
        }
    }
}
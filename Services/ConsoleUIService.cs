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

            if (File.Exists(filePath))
            {
                string asciiArt = File.ReadAllText(filePath);
                Console.WriteLine(asciiArt);
            }
            else
            {
                Console.WriteLine("========================================================");
                Console.WriteLine("         CYBERSECURITY AWARENESS CHATBOT");
                Console.WriteLine("========================================================");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        public string PromptForName()
        {
            string? name;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Please enter your name: ");
                Console.ResetColor();

                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    ShowErrorMessage("Name cannot be empty. Please try again.");
                }

            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void ShowWelcomeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeText($"Hello, {userName}! Welcome to the Cybersecurity Awareness ChatBot.");
            TypeText("I am here to help you stay safe online.");
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
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void ShowExitMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeText($"Goodbye, {userName}. Stay safe online!");
            Console.ResetColor();
        }

        public void ShowDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("========================================================");
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
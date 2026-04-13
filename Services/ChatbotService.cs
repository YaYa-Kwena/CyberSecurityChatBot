using CyberSecurityChatBot.Models;

namespace CyberSecurityChatBot.Services
{
    public class ChatbotService
    {
        public void StartConversation(UserProfile user, ConsoleUIService uiService)
        {
            bool isRunning = true;

            while (isRunning)
            {
                uiService.ShowUserPrompt();
                string input = Console.ReadLine() ?? string.Empty;

                if (IsExitCommand(input))
                {
                    isRunning = false;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    uiService.ShowErrorMessage("You entered an empty message. Please type a question.");
                    continue;
                }

                string response = GetResponse(input, user.Name);
                uiService.ShowBotMessage(response);
                uiService.ShowDivider();
            }
        }

        public string GetResponse(string input, string userName)
        {
            string message = input.Trim().ToLower();

            if (message.Contains("how are you"))
            {
                return $"I am doing well, {userName}, and I am ready to help you stay safe online.";
            }

            if (message.Contains("purpose") || message.Contains("what do you do"))
            {
                return "My purpose is to teach users about cybersecurity awareness and how to stay safe online.";
            }

            if (message.Contains("what can i ask") || message.Contains("help"))
            {
                return "You can ask me about password safety, phishing, suspicious links, and safe browsing.";
            }

            if (message.Contains("password"))
            {
                return "Use strong passwords with a mix of uppercase letters, lowercase letters, numbers, and symbols. Avoid using the same password for multiple accounts.";
            }

            if (message.Contains("phishing"))
            {
                return "Phishing is when criminals try to trick you into sharing personal information through fake emails, messages, or websites. Always verify the sender before clicking anything.";
            }

            if (message.Contains("safe browsing") || message.Contains("browsing"))
            {
                return "Practice safe browsing by visiting trusted websites, avoiding suspicious downloads, and checking that websites use HTTPS.";
            }

            if (message.Contains("link") || message.Contains("suspicious link"))
            {
                return "Do not click suspicious links. Check the full URL carefully and avoid links from unknown messages or urgent-looking emails.";
            }

            return "I didn't quite understand that. Could you rephrase?";
        }

        public bool IsExitCommand(string input)
        {
            string command = input.Trim().ToLower();
            return command == "exit" || command == "quit" || command == "bye";
        }
    }
}
using CyberSecurityChatBot.Models;
using CyberSecurityChatBot.Services;

namespace CyberSecurityChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AudioService audioService = new AudioService();
            ConsoleUIService uiService = new ConsoleUIService();
            ChatbotService chatbotService = new ChatbotService();
            UserProfile user = new UserProfile();

            uiService.SetupConsole();

            audioService.PlayGreeting("Assets/greeting.wav");
            uiService.DisplayHeader("Assets/ascii-art.txt");

            user.Name = uiService.PromptForName();

            uiService.ShowDivider();
            uiService.ShowWelcomeMessage(user.Name);
            uiService.ShowBotMessage("You can ask me about passwords, phishing, safe browsing, or suspicious links.");
            uiService.ShowBotMessage("Type 'exit', 'quit', or 'bye' when you want to close the chatbot.");
            uiService.ShowDivider();

            chatbotService.StartConversation(user, uiService);

            uiService.ShowExitMessage(user.Name);
        }
    }
}
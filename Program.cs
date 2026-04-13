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

            uiService.ShowSectionTitle("Welcome");
            uiService.ShowWelcomeMessage(user.Name);

            uiService.ShowSectionTitle("Instructions");
            uiService.ShowInstructions();

            uiService.ShowSectionTitle("Chat Session");
            chatbotService.StartConversation(user, uiService);

            uiService.ShowExitMessage(user.Name);
        }
    }
}
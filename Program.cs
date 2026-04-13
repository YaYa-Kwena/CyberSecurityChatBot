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
            UserProfile user = new UserProfile();

            uiService.SetupConsole();

            audioService.PlayGreeting("Assets/greeting.wav");
            uiService.DisplayHeader("Assets/ascii-art.txt");

            user.Name = uiService.PromptForName();

            uiService.ShowDivider();
            uiService.ShowWelcomeMessage(user.Name);
            uiService.ShowDivider();
        }
    }
}
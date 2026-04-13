using CyberSecurityChatBot.Services;

namespace CyberSecurityChatBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUIService uiService = new ConsoleUIService();

            uiService.SetupConsole();
            uiService.DisplayHeader("Assets/ascii-art.txt");

            string userName = uiService.PromptForName();
            uiService.ShowDivider();
            uiService.ShowWelcomeMessage(userName);
            uiService.ShowDivider();
        }
    }
}
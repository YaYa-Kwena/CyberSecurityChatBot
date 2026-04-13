using System;
using System.IO;
using System.Media;

namespace CyberSecurityChatBot.Services
{
    public class AudioService
    {
        public void PlayGreeting(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using SoundPlayer player = new SoundPlayer(filePath);
                    player.PlaySync();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Greeting audio file was not found.");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Audio playback error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
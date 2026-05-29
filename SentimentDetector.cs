using System;

namespace CyberSecurityChatBot
{
    public class SentimentDetector
    {
        public string AnalyzeSentiment(string userInput)
        {
            string inputLower = userInput.ToLower();

            if (inputLower.Contains("worried") || inputLower.Contains("scared") || inputLower.Contains("hacked"))
                return "It is completely understandable to feel worried. Cyber threats are stressful, but taking defensive steps helps! ";

            if (inputLower.Contains("frustrated") || inputLower.Contains("annoyed"))
                return "I completely understand your frustration. Security rules can feel tedious, but let's break it down. ";

            if (inputLower.Contains("curious") || inputLower.Contains("learn"))
                return "That is excellent! Staying curious is your best absolute shield online. ";

            return string.Empty;
        }
    }
}
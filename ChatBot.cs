using System;

namespace CyberSecurityChatBot
{
    public class ChatBot
    {
        private readonly MemoryStore _memory = new MemoryStore();
        private readonly SentimentDetector _sentiment = new SentimentDetector();
        private readonly KeywordResponder _responder = new KeywordResponder();

        private string _lastActiveTopic = null;
        public bool IsAwaitingName { get; private set; } = true;

        public string GetVoiceGreetingPath() => System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");

        public string GetAsciiArt()
        {
            return @".--------.
       / .------. \
      / /        \ \
      | |  SAFE  | |
     _| |________| |_
   .' |_|        |_| '.
   '._____ ____ _____.'
   |     .'____'.     |
   '.__.'.'    '.'.__.'
   '.__  | LOCK |  __.'
   |   '.'.____.'.'   |
   '.____'.____.'____.'
   '.________________.'
========================================================
   Stay alert. Stay secure. Stay safe online.
========================================================";
        }

        public string HandleInput(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "I didn't quite understand that. Could you type a question or phrase?"; // Question 7: Error Handling

            if (IsAwaitingName)
            {
                _memory.Save("UserName", userInput.Trim());
                IsAwaitingName = false;
                return $"Pleasure to meet you, {_memory.Recall("UserName")}! Ask me about 'passwords', 'scams', 'privacy', or ask for a 'phishing tip'.";
            }

            string userName = _memory.Recall("UserName");
            string inputLower = userInput.ToLower();

            // Question 4: Conversation Flow
            if ((inputLower.Contains("another") || inputLower.Contains("more") || inputLower.Contains("explain")) && !string.IsNullOrEmpty(_lastActiveTopic))
            {
                return $"Regarding your interest in {_lastActiveTopic}, let's build on that. " + _responder.MatchKeyword(_lastActiveTopic, out _);
            }

            string sentimentPrefix = _sentiment.AnalyzeSentiment(userInput);
            string coreResponse = _responder.MatchKeyword(userInput, out string matchedTopic);

            if (coreResponse != null)
            {
                _lastActiveTopic = matchedTopic;
                if (matchedTopic.Equals("privacy", StringComparison.OrdinalIgnoreCase))
                {
                    _memory.Save("FavTopic", "privacy");
                    return $"{sentimentPrefix}As someone interested in privacy, make sure to review the security settings on your accounts, {userName}!";
                }
                return $"{sentimentPrefix}{userName}, here is what you need to know: {coreResponse}";
            }

            return "I'm not completely sure I understand that query. Could you try rephrasing? You can ask me about password safety, phishing tips, or privacy.";
        }
    }
}
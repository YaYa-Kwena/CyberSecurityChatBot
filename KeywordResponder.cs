using System;
using System.Collections.Generic;

namespace CyberSecurityChatBot
{
    public class KeywordResponder
    {
        private readonly Random _random = new Random();
        private readonly Dictionary<string, string> _staticKeywords = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, List<string>> _randomPools = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public KeywordResponder()
        {
            _staticKeywords["password"] = "Make sure to use strong, unique passwords with a mix of characters. Avoid using personal details!";
            _staticKeywords["scam"] = "Scams rely on creating fake urgency. Always verify the source independently before clicking links.";
            _staticKeywords["privacy"] = "Protect your privacy by limiting what you share on social media and checking app permissions.";

            _randomPools["phishing"] = new List<string>
            {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Check the sender's actual email address carefully. Misspelled domain names are a major red flag.",
                "Never click links from unexpected emails. When in doubt, call the company directly."
            };
        }

        public string MatchKeyword(string userInput, out string matchedKey)
        {
            string inputLower = userInput.ToLower();
            matchedKey = null;

            if (inputLower.Contains("phishing") || inputLower.Contains("tip"))
            {
                matchedKey = "phishing";
                var pool = _randomPools["phishing"];
                return pool[_random.Next(pool.Count)];
            }

            foreach (var key in _staticKeywords.Keys)
            {
                if (inputLower.Contains(key))
                {
                    matchedKey = key;
                    return _staticKeywords[key];
                }
            }
            return null;
        }
    }
}
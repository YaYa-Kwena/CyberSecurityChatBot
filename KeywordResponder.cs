using System;
using System.Collections.Generic;

namespace CyberSecurityChatBot
{
    public class KeywordResponder
    {
        private readonly Random _random = new Random();

        // Using a Generic Dictionary containing Generic Lists
        private readonly Dictionary<string, List<string>> _randomPools = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

        public KeywordResponder()
        {
            // In-depth Password Responses
            _randomPools["password"] = new List<string>
            {
                "Instead of complex, hard-to-remember passwords, use 'Passphrases'—a string of 4 or 5 unrelated words (e.g., 'CorrectHorseBatteryStaple'). They are mathematically harder for computers to crack but much easier for humans to remember.",
                "Never reuse passwords across different sites. If one site gets breached, hackers use 'Credential Stuffing' bots to test your password on banking and email sites. Use a trusted Password Manager to generate and store unique keys.",
                "Even the strongest password isn't enough anymore. You must enable Multi-Factor Authentication (MFA) via an authenticator app (like Authy or Google Authenticator) rather than SMS, as SMS texts can be intercepted via SIM-swapping."
            };

            // In-depth Scam Responses
            _randomPools["scam"] = new List<string>
            {
                "Modern scams rely on psychological manipulation, specifically creating a false sense of extreme urgency or fear. If an email, call, or text demands immediate action or payment, it is almost certainly a scam. Stop, breathe, and verify independently.",
                "Beware of 'Spear-Phishing'. Scammers now use your public social media data to craft highly personalized attacks, pretending to be your boss or a known relative in distress. Always verify 'out-of-band'—if they email you, call their known phone number to confirm.",
                "With the rise of AI, voice-cloning scams are increasing. Scammers can clone a loved one's voice using just a 3-second social media clip. Establish a secret 'safe word' with your family so you can instantly verify their identity over the phone."
            };

            // In-depth Privacy Responses
            _randomPools["privacy"] = new List<string>
            {
                "Your digital footprint is permanent. Regularly audit your 'OAuth' connections—those apps you signed into using 'Continue with Google' or 'Continue with Facebook'. Revoke access to apps you no longer use, as they silently harvest your data in the background.",
                "True privacy requires End-to-End Encryption (E2EE). When using messaging apps, ensure E2EE is enabled by default (like in Signal or WhatsApp) so that even the service provider cannot read your messages or hand them over to third parties.",
                "Limit the 'Zero-Party Data' you give away. Stop participating in social media quizzes (e.g., 'What is your pirate name based on your first pet and street you grew up on?'). These are actually designed to harvest common security question answers."
            };

            // In-depth Phishing Responses
            _randomPools["phishing"] = new List<string>
            {
                "Phishing links often hide behind homoglyph attacks—using characters from different alphabets that look identical to English letters (e.g., a Cyrillic 'a' in apple.com). Always manually type critical URLs into your browser rather than clicking email links.",
                "Don't just check the sender's display name; click on it to reveal the actual email address. A sophisticated phishing attack might say 'Microsoft Security' but the underlying email address is actually 'admin@secure-update-xyz.com'.",
                "A padlock icon in your browser's address bar does NOT mean the site is safe; it simply means the connection is encrypted. Scammers can easily obtain free SSL certificates. Always verify the domain name itself."
            };
        }

        public string MatchKeyword(string userInput, out string matchedKey)
        {
            string inputLower = userInput.ToLower();
            matchedKey = null;

            // Dynamically scan the user input against all our random pools
            foreach (var key in _randomPools.Keys)
            {
                // also check for the word "tip" to trigger the phishing pool based on your earlier setup
                if (inputLower.Contains(key) || (key == "phishing" && inputLower.Contains("tip")))
                {
                    matchedKey = key;
                    var pool = _randomPools[key];

                    // Return a random deep-dive response from the matched pool
                    return pool[_random.Next(pool.Count)];
                }
            }

            return null; // Returns null if no keyword is found, allowing ChatBot.cs to handle the error
        }
    }
}
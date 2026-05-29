using System;
using System.Collections.Generic;

namespace CyberSecurityChatBot
{
    public class MemoryStore
    {
        // Rubric Requirement: Use a generic collection to solve a programming problem
        private readonly Dictionary<string, string> _userMemory = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void Save(string key, string value) => _userMemory[key] = value;

        public string Recall(string key) => _userMemory.TryGetValue(key, out var value) ? value : null;
    }
}

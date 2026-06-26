using System;
using System.Collections.Generic;
using System.Linq;

public class ActivityLogger
{
    private List<string> logs = new List<string>();

    public void LogAction(string description)
    {
        string timestamp = DateTime.Now.ToString("HH:mm:ss");
        logs.Add($"[{timestamp}] {description}");
    }

    public List<string> GetRecentLogs()
    {
        // Keeps the layout clean by grabbing up to the last 10 entries as required
        return logs.AsEnumerable().Reverse().Take(10).Reverse().ToList();
    }
}
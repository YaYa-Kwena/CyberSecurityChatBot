using System;

public enum UserIntent { AddTask, ViewTasks, StartQuiz, ViewLog, GeneralCybersecurity }

public class NlpParser
{
    public static UserIntent DetermineIntent(string input)
    {
        // Normalize the text to lower case so spacing or caps don't break the rules
        string cleanInput = input.ToLower().Trim();

        // Check for variation combinations using simple .Contains mapping
        if (cleanInput.Contains("add") || cleanInput.Contains("remind") || cleanInput.Contains("task") || cleanInput.Contains("save"))
            return UserIntent.AddTask;

        if (cleanInput.Contains("show tasks") || cleanInput.Contains("list tasks") || cleanInput.Contains("view tasks") || cleanInput.Contains("checklist"))
            return UserIntent.ViewTasks;

        if (cleanInput.Contains("quiz") || cleanInput.Contains("game") || cleanInput.Contains("test me") || cleanInput.Contains("play"))
            return UserIntent.StartQuiz;

        if (cleanInput.Contains("activity log") || cleanInput.Contains("what have you done") || cleanInput.Contains("history"))
            return UserIntent.ViewLog;

        return UserIntent.GeneralCybersecurity;
    }
}
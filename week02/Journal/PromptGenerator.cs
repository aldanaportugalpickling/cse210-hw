using System;
using System.Collections.Generic;
public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best part of my life today?",
        "What obstacles am I facing today?",
        "What was the strongest emotion I felt today?",
        "What am I grateful for today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random(); 
        int index = rand.Next(_prompts.Count); 
        return _prompts[index];
    }
}
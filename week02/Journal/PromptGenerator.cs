public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I learn today?",
        "What am I grateful for today?",
        "What is something small I accomplished today?",
        "What thought has been on my mind the most today?",
        "What made me smile or laugh today?",
        "What did I notice about the world around me today?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}
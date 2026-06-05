public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _randomizedPrompts;
    private List<string> _randomizedQuestions;
    private int _promptIndex;
    private int _questionIndex;

    public ReflectingActivity()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration = 10;

        _prompts = new List<string>()
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

        _questions = new List<string>()
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

        _randomizedPrompts = GetShuffledItems(_prompts);
        _randomizedQuestions = GetShuffledItems(_questions);
        _promptIndex = 0;
        _questionIndex = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    private void PerformActivity()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();

        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DisplayQuestions();
    }

    private string GetRandomPrompt()
    {
        string prompt = _randomizedPrompts[_promptIndex];
        _promptIndex = _promptIndex + 1;
        if (_promptIndex >= _randomizedPrompts.Count)
        {
            _randomizedPrompts = GetShuffledItems(_prompts);
            _promptIndex = 0;
        }
        return prompt;
    }

    private string GetRandomQuestion()
    {
        string question = _randomizedQuestions[_questionIndex];
        _questionIndex = _questionIndex + 1;
        if (_questionIndex >= _randomizedQuestions.Count)
        {
            _randomizedQuestions = GetShuffledItems(_questions);
            _questionIndex = 0;
        }
        return question;
    }

    private void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        string prompt = GetRandomPrompt();
        Console.WriteLine("--- " + prompt + " ---");
        Console.WriteLine();
    }

    private void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write("> " + question + " ");
            ShowSpinner(8);
            Console.WriteLine();
        }
    }
}
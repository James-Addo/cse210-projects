public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _randomizedPrompts;
    private int _promptIndex;


    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration = 10;

        _prompts = new List<string>()
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

        _randomizedPrompts = GetShuffledItems(_prompts);
        _promptIndex = 0;
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

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("--- " + GetRandomPrompt() + " ---");
        Console.WriteLine();
        Console.WriteLine("You will begin in:");

        ShowCountDown(5);

        Console.WriteLine("Start listing items!");
        Console.WriteLine();

        List<string> userList = GetListFromUser();
        _count = userList.Count;
        Console.WriteLine();
        Console.WriteLine("You listed " + _count + " items!");
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

    private List<string> GetListFromUser()
    {
        List<string> results = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan timeLeft = endTime - currentTime;
            int remainingSeconds = (int)timeLeft.TotalSeconds;

            if (remainingSeconds <= 0) break;

            Console.Write(">");
            string input = Console.ReadLine();
            if (input != "")
            {
                results.Add(input);
            }
        }
        return results;
    }
}
public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = " ";
        _description = " ";
        _duration = 0;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the " + _name + " Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string userInput = Console.ReadLine();
        _duration = int.Parse(userInput);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine("You have completed " + _duration + " seconds of the " + _name + " Activity.");
        ShowSpinner(3);
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        List<string> spinnerChars = new List<string>() { "|", "/", "-", "\\" };
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = i + 1;
            if (i >= spinnerChars.Count)
            {
                i = 0;
            }
        }
    }

    protected List<string> GetShuffledItems(List<string> originalList)
    {
        List<string> shuffledItems = new List<string>(originalList);

        Random randomGenerator = new Random();

        for (int i = shuffledItems.Count - 1; i > 0; i--)
        {
            int randomIndex = randomGenerator.Next(i + 1);

            string itemAtCurrentPosition = shuffledItems[i];
            string itemAtRandom = shuffledItems[randomIndex];
            shuffledItems[i] = itemAtRandom;
            shuffledItems[randomIndex] = itemAtCurrentPosition;
        }

        return shuffledItems;
    }
}
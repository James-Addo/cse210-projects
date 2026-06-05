public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration = 0;
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

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            ShowCountDown(5);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.Write("Breathe out... ");
            ShowCountDown(5);
            Console.WriteLine();
        }
    }
}
public class Menu
{
    private Dictionary<string, int> _activityLog;

    public Menu()
    {
        _activityLog = new Dictionary<string, int>()
            {
                {"Breathing", 0},
                {"Reflecting", 0},
                {"Listing", 0}
            };
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Application!");
            ShowLog();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RunBreathingActivity();
            }
            else if (choice == "2")
            {
                RunReflectingActivity();
            }
            else if (choice == "3")
            {
                RunListingActivity();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                Thread.Sleep(1000);
            }
        }
    }

    private void RunBreathingActivity()
    {
        BreathingActivity activity = new BreathingActivity();
        activity.Run();
        _activityLog["Breathing"] = _activityLog["Breathing"] + 1;
    }

    private void RunReflectingActivity()
    {
        ReflectingActivity activity = new ReflectingActivity();
        activity.Run();
        _activityLog["Reflecting"] = _activityLog["Reflecting"] + 1;
    }

    private void RunListingActivity()
    {
        ListingActivity activity = new ListingActivity();
        activity.Run();
        _activityLog["Listing"] = _activityLog["Listing"] + 1;
    }

    private void ShowLog()
    {
        Console.WriteLine("Activities completed, this session:");
        foreach (string activityName in _activityLog.Keys)
        {
            int timesDone = _activityLog[activityName];
            Console.WriteLine(" " + activityName + ": " + timesDone);
        }
    }
}
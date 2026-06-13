public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        int userChoice = 0;

        while (userChoice != 6)
        {
            DisplayPlayerInfo();
            ShowMenu();

            Console.Write("Select a choice from the menu: ");
            userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                CreateGoal();
            }
            else if (userChoice == 2)
            {
                ListGoalDetails();
            }
            else if (userChoice == 3)
            {
                SaveGoals();
            }
            else if (userChoice == 4)
            {
                LoadGoals();
            }
            else if (userChoice == 5)
            {
                RecordEvent();
            }
            else if (userChoice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid choice. Try again.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level: {_level}");
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine(" 1. Create New Goal");
        Console.WriteLine(" 2. List Goals");
        Console.WriteLine(" 3. Save Goals");
        Console.WriteLine(" 4. Load Goals");
        Console.WriteLine(" 5. Record Event");
        Console.WriteLine(" 6. Quit");
    }

    private void ListGoalNames()
    {
        int number = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{number}. {goal.GetDetailsString()}");
            number++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        int goalType = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == 1)
        {
            SimpleGoal simple = new SimpleGoal(name, description, points);
            _goals.Add(simple);
        }
        else if (goalType == 2)
        {
            EternalGoal eternal = new EternalGoal(name, description, points);
            _goals.Add(eternal);
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal checklist = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklist);
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        goalNumber = goalNumber - 1;

        Goal goal = _goals[goalNumber];

        if (goal is SimpleGoal)
        {
            SimpleGoal simple = (SimpleGoal)goal;
            if (simple.IsComplete())
            {
                Console.WriteLine("You already completed this goal.");
                return;
            }
        }

        goal.RecordEvent();
        int pointsEarned = goal.GetPoints();

        if (goal is ChecklistGoal)
        {
            ChecklistGoal checklist = (ChecklistGoal)goal;
            if (checklist.IsComplete())
            {
                pointsEarned = pointsEarned + checklist.GetBonus();
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points! Bonus earned!");
            }
            else
            {
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }

        _score = _score + pointsEarned;

        int newLevel = (_score / 100) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"LEVEL UP! You are now at Level {_level}!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        StreamWriter outputFile = new StreamWriter(filename);

        outputFile.WriteLine(_score);
        outputFile.WriteLine(_level);

        foreach (Goal goal in _goals)
        {
            outputFile.WriteLine(goal.GetStringRepresentation());
        }

        outputFile.Close();
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        _goals.Clear();

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                SimpleGoal goal = new SimpleGoal(name, description, points);
                if (isComplete == true)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (goalType == "ChecklistGoal")
            {
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);

                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded!");
    }
}
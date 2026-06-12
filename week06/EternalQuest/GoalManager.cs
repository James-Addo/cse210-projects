using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                CreateGoal();
            }
            else if (choice == 2)
            {
                ListGoalDetails();
            }
            else if (choice == 3)
            {
                SaveGoals();
            }
            else if (choice == 4)
            {
                LoadGoals();
            }
            else if (choice == 5)
            {
                RecordEvent();
            }
            else if (choice == 6)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Sorry, that is not a valid choice. Please try again.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine("You have " + _score + " points.");
    }

    public void ListGoalNames()
    {
        int number = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(number + ". " + goal.GetDetailsString());
            number = number + 1;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        int number = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(number + ". " + goal.GetDetailsString());
            number = number + 1;
        }
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
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }
        else if (goalType == 2)
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        Goal selectedGoal = _goals[goalNumber];

        if (selectedGoal is SimpleGoal)
        {
            if (selectedGoal.IsComplete() == false)
            {
                // Use GetPoints() instead of _points
                _score = _score + selectedGoal.GetPoints();
                selectedGoal.RecordEvent();
                Console.WriteLine("Congratulations! You earned " + selectedGoal.GetPoints() + " points!");
            }
            else
            {
                Console.WriteLine("You already completed this goal.");
            }
        }
        else if (selectedGoal is EternalGoal)
        {
            _score = _score + selectedGoal.GetPoints();
            selectedGoal.RecordEvent();
            Console.WriteLine("Congratulations! You earned " + selectedGoal.GetPoints() + " points!");
        }
        else if (selectedGoal is ChecklistGoal)
        {
            ChecklistGoal checklistGoal = (ChecklistGoal)selectedGoal;

            bool wasCompleteBefore = checklistGoal.IsComplete();

            checklistGoal.RecordEvent();

            bool isCompleteNow = checklistGoal.IsComplete();

            if (wasCompleteBefore == false && isCompleteNow == true)
            {
                int pointsForGoal = checklistGoal.GetPoints();
                int bonusPoints = checklistGoal.GetBonus();
                int totalPointsEarned = pointsForGoal + bonusPoints;

                _score = _score + totalPointsEarned;
                Console.WriteLine("Congratulations! You have earned " + totalPointsEarned + " points! Bonus earned!");
            }
            else
            {
                int pointsForGoal = checklistGoal.GetPoints();
                _score = _score + pointsForGoal;
                Console.WriteLine("Congratulations! You have earned " + pointsForGoal + " points!");
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
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
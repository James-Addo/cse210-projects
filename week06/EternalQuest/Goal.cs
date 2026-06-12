using System;

public abstract class Goal
{
    // Keep points protected so child classes can use it
    protected int _points;

    protected string _shortName;
    protected string _description;

    // Constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Method to let other classes read points safely
    public int GetPoints()
    {
        return _points;
    }

    // Each goal type must decide how to record an event
    public abstract void RecordEvent();

    // Each goal type must decide if it is complete
    public abstract bool IsComplete();

    // Show goal details with [X] or [ ]
    public virtual string GetDetailsString()
    {
        string status;

        if (IsComplete() == true)
        {
            status = "[X]";
        }
        else
        {
            status = "[ ]";
        }

        // Using format string $"" instead of +
        string result = $"{status} {_shortName} ({_description})";
        return result;
    }
    // Save goal to a text file
    public abstract string GetStringRepresentation();
}
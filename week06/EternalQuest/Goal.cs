using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

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

        string result = $"{status} {_shortName} ({_description})";

        return result;
    }
}